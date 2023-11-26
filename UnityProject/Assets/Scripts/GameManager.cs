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

public enum TurnPhases
{
    Morning,
    Afternoon,
    Evening
}
public class GameManager : MonoBehaviourSingleton<GameManager>
{
    [Tooltip("Reference to the player resources script.")]
    public Resources playerResources;

    [SerializeField, Tooltip("Reference to the player attributes script.")]
    public Attributes playerAttributes;

    [SerializeField, Tooltip("Reference to the game properties")]
    public GameProperties gameProperties;

    [SerializeField, Tooltip("The button that will be instantiated for player actions.")]
    private GameObject playerActionButtonPrefab;

    [SerializeField, Tooltip("The parent to hold all the buttons.")]
    private Transform buttonLayoutParent;

    public int foodConsumedPerDay = 2;
    public int waterConsumedPerDay = 1;
    
    public TurnPhases currentPhase;
    
    private List<PlayerAction> _playerActions;

    private List<GameObject> _buttons;

    public void Awake()
    {
        _playerActions = new List<PlayerAction>();
        
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
            EndOfDay();
            StartOfDay();
            DisplayActions(_playerActions);
        }
        
        if (newPhase == TurnPhases.Afternoon)
        {
            DisplayActions(_playerActions);
        }
        
        if (newPhase == TurnPhases.Evening)
        {
            DisplayActions(_playerActions);
        }

        currentPhase = newPhase;
    }
   
    private void InitializeGame()
    {
        gameProperties.currentDay = 0;
        gameProperties.playerTileIndex = 0;
        
        SetupActions();        
        
        playerResources.food = 5;
        playerResources.water = 3;
        playerAttributes.houseStamina = 10;
    }

    private void SetupActions()
    {
       
        _playerActions.Clear();

        if (playerAttributes.houseStamina >= gameProperties.nextTile.StaminaCost)
        {
            _playerActions.Add(new MoveHouseAction());
        }

        _playerActions.Add(new ForageAction());
        _playerActions.Add(new ScavengeAction());
        _playerActions.Add(new RestAction());
    }

    private void StartGame()
    {
        SwitchTurnPhase(TurnPhases.Morning);
        gameProperties.GenerateNewTile();
        gameProperties.GenerateNewTile();
    }
    
    private void StartOfDay()
    {
        gameProperties.currentDay++;
    }

    private void EndOfDay()
    {
        playerResources.food -= foodConsumedPerDay;
        playerResources.water -= waterConsumedPerDay;

        if (playerResources.food <= 0 || playerResources.water <= 0)
        {
            //TODO: add the lose state and stuff here.
        }
    }

    private void DisplayActions(List<PlayerAction> actionsToShow)
    {
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
}
