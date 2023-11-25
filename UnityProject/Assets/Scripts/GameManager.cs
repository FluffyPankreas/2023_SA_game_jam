using System.Collections.Generic;
using DarkMushroomGames.Architecture;
using PlayerActions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

//TODO: Add a message when the baba yaga starts chasing the player
//TODO: have the regions affect the actions
    // Desert affects water
    // Forest allows for hunting.
//TODO: Add "explore the house" as an action.(based on random encounter stuff.)


public class GameManager : MonoBehaviourSingleton<GameManager>
{
    public enum TurnPhases
    {
        Morning,
        Afternoon,
        Evening
    }
    
    [Tooltip("Reference to the player resources script.")]
    public Resources playerResources;

    [SerializeField, Tooltip("Reference to the player attributes script.")]
    private Attributes playerAttributes;

    [SerializeField, Tooltip("Reference to the game properties")]
    public GameProperties gameProperties;

    [SerializeField, Tooltip("The number of actions that will be selected from all possible actions.")]
    private int numberofActionsPerPhase = 3;

    [SerializeField, Tooltip("The button that will be instantiated for player actions.")]
    private GameObject playerActionButtonPrefab;

    [SerializeField, Tooltip("The parent to hold all the buttons.")]
    private Transform buttonLayoutParent;

    public TurnPhases currentPhase;
    
    private List<PlayerAction> _morningActions;
    private List<PlayerAction> _afternoonActions;
    private List<PlayerAction> _eveningActions;

    private List<GameObject> _buttons;

    public void Awake()
    {
        _morningActions = new List<PlayerAction>();
        _afternoonActions = new List<PlayerAction>();
        _eveningActions = new List<PlayerAction>();
        
        _buttons = new List<GameObject>();
    }
    
    public void Start()
    {
        InitializeGame();
        StartGame();
    }

    public void FinishAction()
    {
        Debug.Log("Action Finished.");
        if (currentPhase == TurnPhases.Morning)
        {
            SwitchTurnPhase(TurnPhases.Afternoon);
        }else if (currentPhase == TurnPhases.Afternoon)
        {
            SwitchTurnPhase(TurnPhases.Evening);
        }else if (currentPhase == TurnPhases.Evening)
        {
            SwitchTurnPhase(TurnPhases.Morning);
        }
    }

    private void SwitchTurnPhase(TurnPhases newPhase)
    {
        if (newPhase == TurnPhases.Morning)
        {
            StartOfDay();
            DisplayActions(_morningActions);
        }
        
        if (newPhase == TurnPhases.Afternoon)
        {
            DisplayActions(_afternoonActions);
        }
        
        if (newPhase == TurnPhases.Evening)
        {
            DisplayActions(_eveningActions);
            EndOfDay();
        }

        currentPhase = newPhase;
    }
   
    private void InitializeGame()
    {
        gameProperties.currentDay = 0;
        
        // Setup Morning Actions
        _morningActions.Clear();
        _morningActions.Add(new MoveHouseAction());
        _morningActions.Add(new ForageAction());
        _morningActions.Add(new ScavengeAction());
        
        // Setup Afternoon Actions
        _afternoonActions.Add(new MoveHouseAction());
        _afternoonActions.Add(new ForageAction());
        _afternoonActions.Add(new ScavengeAction());
        
        // Setup Evening Actions
        _eveningActions.Add(new MoveHouseAction());
        _eveningActions.Add(new ForageAction());
        _eveningActions.Add(new ScavengeAction());

        playerResources.food = 5;
        playerResources.water = 5;
    }

    private void StartGame()
    {
        SwitchTurnPhase(TurnPhases.Morning);
        gameProperties.GenerateNewTile();
    }
    
    private void StartOfDay()
    {
        gameProperties.GenerateNewTile();
        gameProperties.currentDay++;
    }

    private void EndOfDay()
    {
        playerResources.food -= 3;
        playerResources.water -= 1;

        if (playerResources.food <= 0 || playerResources.water <= 0)
        {
            Debug.Log("LOSE.");
        }

        StartOfDay();
    }

    private void DisplayActions(List<PlayerAction> actionsToShow)
    {
        Debug.Log("Displaying Actions.");

        foreach (var button in _buttons)
        {
            Destroy(button);
        }
        _buttons.Clear();

        foreach (var playerAction in actionsToShow)
        {
            var button = Instantiate(playerActionButtonPrefab, buttonLayoutParent);
            _buttons.Add(button);
            button.SetActive(true);
            
            button.GetComponentInChildren<TextMeshProUGUI>().text = playerAction.ButtonName;
            button.GetComponent<Button>().onClick.AddListener(playerAction.CalculateResult);
        }
    }

    /// <summary>
    /// Selects a subset of actions from the list and returns the subset.
    /// </summary>
    /// <param name="allActions">All the actions to choose a subset from.</param>
    private List<PlayerAction> SelectActions(List<PlayerAction> allActions)
    {
        if (allActions.Count < numberofActionsPerPhase)
            return allActions;

        List<PlayerAction> selectedActions = new List<PlayerAction>();

        for (int i = 0; i < numberofActionsPerPhase; i++)
        {
            selectedActions = new List<PlayerAction>();
        }

        return selectedActions;
    }
}
