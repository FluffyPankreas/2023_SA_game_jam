using System.Collections.Generic;
using DarkMushroomGames.Architecture;
using PlayerActions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviourSingleton<GameManager>
{
    [SerializeField, Tooltip("Reference to the player resources script.")]
    private Resources playerResources;

    [SerializeField, Tooltip("Reference to the player attributes script.")]
    private Attributes playerAttributes;

    [SerializeField, Tooltip("The number of actions that will be selected from all possible actions.")]
    private int numberofActionsPerPhase = 3;

    [SerializeField, Tooltip("The button that will be instantiated for player actions.")]
    private GameObject playerActionButtonPrefab;

    [SerializeField, Tooltip("The parent to hold all the buttons.")]
    private Transform buttonLayoutParent;

    private List<PlayerAction> _morningActions;
    private List<PlayerAction> _afternoonActions;
    private List<PlayerAction> _eveningActions;

    private List<GameObject> _buttons;

    // Building actions should be added
    // Location actions

    public void Awake()
    {
        _morningActions = new List<PlayerAction>();
        _buttons = new List<GameObject>();
    }
    
    public void Start()
    {
        InitializeGame();
        StartGame();
    }

    private void InitializeGame()
    {
        // Setup Morning Actions
        _morningActions.Clear();
        _morningActions.Add(new MoveHouseAction());
        _morningActions.Add(new ForageAction());
        
        // Setup Afternoon Actions
        
        // Setup Evening Actions
    }

    private void StartGame()
    {
        DisplayActions(_morningActions);
    }
    
    private void StartOfDay()
    {
        // Start of day -> Morning action -> Afternoon Action -> Evening Action -> End of Day
    }

    private void EndOfDay()
    {
        // Do end of day calculations and see if the player loses.
    }

    private void DisplayActions(List<PlayerAction> actionsToShow)
    {
        Debug.Log("Displaying Actions.");
        //Setup the UI to show the actions

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
