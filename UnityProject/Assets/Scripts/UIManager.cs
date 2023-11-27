using DarkMushroomGames.Architecture;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviourSingleton<UIManager>
{
    [Header("Player Information")]
    [SerializeField] private TextMeshProUGUI foodLabel;
    [SerializeField] private TextMeshProUGUI waterLabel;
    [SerializeField] private TextMeshProUGUI woodLabel;
    [SerializeField] private TextMeshProUGUI hitPointsLabel;

    [Header("Game Information")]
    [SerializeField] private TextMeshProUGUI phasesLabel;
    [SerializeField] private TextMeshProUGUI dayLabel;
    [SerializeField] private TextMeshProUGUI playerIndexLabel;
    [SerializeField] private TextMeshProUGUI babaYagaIndexLabel;

    [Header("Current Tile")]
    [SerializeField] private TextMeshProUGUI currentTileBiomeLabel;
    [SerializeField] private TextMeshProUGUI currentTileWeatherLabel;
    [SerializeField] private TextMeshProUGUI currentTileFaunaLabel;
    [SerializeField] private TextMeshProUGUI currentTileHasCityLabel;
    [SerializeField] private TextMeshProUGUI currentTileCostToMoveLabel;
    
    [Header("Next Tile")]
    [SerializeField] private TextMeshProUGUI nextTileBiomeLabel;
    [SerializeField] private TextMeshProUGUI nextTileWeatherLabel;
    [SerializeField] private TextMeshProUGUI nextTileFaunaLabel;
    [SerializeField] private TextMeshProUGUI nextTileHasCityLabel;
    [SerializeField] private TextMeshProUGUI nextTileCostToMoveLabel;

    [Header("Costs")] 
    [SerializeField] private TextMeshProUGUI movementWoodCostLabel;
    
    public void Update()
    {
        foodLabel.text = GameManager.Instance.playerResources.food.ToString();
        waterLabel.text = GameManager.Instance.playerResources.water.ToString();
        woodLabel.text = GameManager.Instance.playerResources.wood.ToString();
        hitPointsLabel.text = GameManager.Instance.playerAttributes.houseHitPoints.ToString(); 

        phasesLabel.text = GameManager.Instance.currentPhase.ToString();
        dayLabel.text = "Day# " + GameManager.Instance.gameProperties.currentDay.ToString();
        playerIndexLabel.text = "PlayerIndex: " + GameManager.Instance.gameProperties.playerTileIndex;
        babaYagaIndexLabel.text = "BabaYagaIndex: " + GameManager.Instance.gameProperties.babaYagaTileIndex;
        

        currentTileBiomeLabel.text = "Biome: " + GameManager.Instance.gameProperties.currentTile.Biome;
        currentTileWeatherLabel.text = "Weather: " + GameManager.Instance.gameProperties.currentTile.WeatherCondition;
        currentTileFaunaLabel.text = "Fauna: " + GameManager.Instance.gameProperties.currentTile.Fauna;
        currentTileHasCityLabel.text = "HasCity: " + GameManager.Instance.gameProperties.currentTile.HasSettlement;
        currentTileCostToMoveLabel.text = "CostToMove: " + GameManager.Instance.gameProperties.currentTile.TravelCost;
        
        nextTileBiomeLabel.text = "Biome: " + GameManager.Instance.gameProperties.nextTile.Biome;
        nextTileWeatherLabel.text = "Weather: " + GameManager.Instance.gameProperties.nextTile.WeatherCondition;
        nextTileFaunaLabel.text = "Fauna: " + GameManager.Instance.gameProperties.nextTile.Fauna;
        nextTileHasCityLabel.text = "HasCity: " + GameManager.Instance.gameProperties.nextTile.HasSettlement;
        nextTileCostToMoveLabel.text = "CostToMove: " + GameManager.Instance.gameProperties.nextTile.TravelCost;

        movementWoodCostLabel.text = GameManager.Instance.gameProperties.nextTile.TravelCost.ToString();
    }
}
