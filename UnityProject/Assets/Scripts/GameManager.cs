using System.Collections.Generic;
using DarkMushroomGames.Architecture;
using PlayerActions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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

    public DayNightCycle dayNightCycler;
    public TurnPhases currentPhase;

    public TileManager tileManager;

    public Animator houseAnimator;
    public GameObject babaYagaSprite;

    public GameObject gameOverScreen;
    public TextMeshProUGUI gameOverMessage;
    
    private List<PlayerAction> _playerActions;

    private List<GameObject> _buttons;

    private bool _babaYagaChasing;

    public GameObject overnightPanel;
    public TextMeshProUGUI _waterCostLabel;
    public TextMeshProUGUI _foodCostLabel;
    public TextMeshProUGUI _woodCostLabel;
    public TextMeshProUGUI _hitPointCostLabel;


    private int endOfTurnWaterCost;
    private int endOfTurnFoodCost;
    private int endOfTurnWoodCost;
    private int endOfTurnHitPointCost;
    
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
        SetupActions(newPhase);
        
        babaYagaSprite.SetActive(false);
        
        if ((gameProperties.playerTileIndex - gameProperties.babaYagaTileIndex <= 1) && _babaYagaChasing)
        {
            babaYagaSprite.SetActive(true);
        }

        if (newPhase == TurnPhases.Morning)
        {
            EndOfDay();
            StartOfDay();
            dayNightCycler.SetPreset((int)TurnPhases.Morning);
            DisplayActions(_playerActions);
        }
        
        if (newPhase == TurnPhases.Afternoon)
        {
            dayNightCycler.SetPreset((int)TurnPhases.Afternoon);
            DisplayActions(_playerActions);
        }
        
        if (newPhase == TurnPhases.Evening)
        {
            dayNightCycler.SetPreset((int)TurnPhases.Evening);
            overnightPanel.SetActive(true);
            // Water Costs
            endOfTurnWaterCost = 0;
            endOfTurnWaterCost += waterConsumedPerDay;
            if (gameProperties.currentTile.Biome == Biomes.Desert)
            {
                Debug.Log("More water because of desert. ");
                endOfTurnWaterCost++;
            }
            _waterCostLabel.text = endOfTurnWaterCost.ToString();
            
            // Food Costs
            endOfTurnFoodCost = 0;
            endOfTurnFoodCost += foodConsumedPerDay;
            _foodCostLabel.text = endOfTurnFoodCost.ToString();
            
            // Wood Costs
            endOfTurnWoodCost = 0;
            _woodCostLabel.text = endOfTurnWoodCost.ToString();

            // HitPoint Cost
            endOfTurnHitPointCost = 0;
            if (gameProperties.currentTile.Biome == Biomes.Swamp)
            {
                endOfTurnHitPointCost++;
            }
            _hitPointCostLabel.text = endOfTurnHitPointCost.ToString();
            
            DisplayActions(_playerActions);
        }

        currentPhase = newPhase;
        
        
    }
   
    private void InitializeGame()
    {
        tileManager.CreateTile(gameProperties.GenerateNewTile());
        tileManager.CreateTile(gameProperties.GenerateNewTile());

        gameProperties.currentDay = 0;
        gameProperties.playerTileIndex = 0;

        babaYagaSprite.SetActive(false);
        
        playerResources.food = 5;
        playerResources.water = 3;
        playerResources.wood = 2;
        
        playerAttributes.houseHitPoints = 3;
        
        _babaYagaChasing = false;
        gameProperties.babaYagaTileIndex = 0;
    }

    private void SetupActions(TurnPhases newPhase)
    {
       
        _playerActions.Clear();

        Debug.Log(playerResources.wood >= gameProperties.nextTile.TravelCost);
        Debug.Log(newPhase != TurnPhases.Evening);
        Debug.Log("Should the button appear?: " + ((playerResources.wood >= gameProperties.nextTile.TravelCost) &&
                                                   (newPhase != TurnPhases.Evening)));
        if ((playerResources.wood >= gameProperties.nextTile.TravelCost) && (newPhase != TurnPhases.Evening))
        {
            _playerActions.Add(new MoveHouseAction());
        }

        _playerActions.Add(new ForageAction());
        _playerActions.Add(new ScavengeAction());
    }

    private void StartGame()
    {
        SwitchTurnPhase(TurnPhases.Morning);
      
    }
    
    private void StartOfDay()
    {
        gameProperties.currentDay++;
        overnightPanel.SetActive(false);
    }

    private void EndOfDay()
    {
        playerResources.water -= endOfTurnWaterCost;
        playerResources.food -= endOfTurnFoodCost;
        playerResources.wood -= endOfTurnWoodCost;
        playerAttributes.houseHitPoints -= endOfTurnHitPointCost;
        
        HandleBabaYagaChase();
        
        if (playerResources.food <= 0 || playerResources.water <= 0)
        {
            gameOverMessage.text = "You ran out of food and water.";
            gameOverScreen.SetActive(true);
        }

        if (playerAttributes.houseHitPoints <= 0)
        {
            gameOverMessage.text = "The Baba Yaga caught up with you!";
            gameOverScreen.SetActive(true);
        }
    }

    private void HandleBabaYagaChase()
    {
        
        if (gameProperties.currentDay >= 2 && !_babaYagaChasing)
        {
            Debug.Log("The Baba Yaga has started chasing you!");
            _babaYagaChasing = true;
        }

        if (_babaYagaChasing)
        {
            gameProperties.babaYagaTileIndex++;
            if (gameProperties.babaYagaTileIndex > gameProperties.playerTileIndex)
                gameProperties.babaYagaTileIndex = gameProperties.playerTileIndex;
            
            if (gameProperties.babaYagaTileIndex == gameProperties.playerTileIndex)
            {
                Debug.Log("The Baba Yaga has caught up with you, and destroyed the house!");
                playerAttributes.houseHitPoints -= 1;
                gameProperties.babaYagaTileIndex -= 3;
                if (gameProperties.babaYagaTileIndex < 0)
                    gameProperties.babaYagaTileIndex = 0;
            }    
            
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
