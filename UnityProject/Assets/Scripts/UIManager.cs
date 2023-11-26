using DarkMushroomGames.Architecture;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class UIManager : MonoBehaviourSingleton<UIManager>
{
    [Header("Player Information")]
    [SerializeField] private TextMeshProUGUI foodLabel;
    [SerializeField] private TextMeshProUGUI waterLabel;
    [SerializeField] private TextMeshProUGUI woodLabel;
    [SerializeField] private TextMeshProUGUI staminaLabel;

    [Header("Game Information")]
    [SerializeField] private TextMeshProUGUI phasesLabel;

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
    
    public void Update()
    {
        foodLabel.text = "Food: " + GameManager.Instance.playerResources.food;
        waterLabel.text = "Water: " + GameManager.Instance.playerResources.water;
        woodLabel.text = "Wood: " + GameManager.Instance.playerResources.wood;
        staminaLabel.text = "Stamina: " + GameManager.Instance.playerAttributes.houseStamina;

        phasesLabel.text = GameManager.Instance.currentPhase.ToString();

        currentTileBiomeLabel.text = "Biome: " + GameManager.Instance.gameProperties.currentTile.Biome;
        currentTileWeatherLabel.text = "Weather: " + GameManager.Instance.gameProperties.currentTile.WeatherCondition;
        currentTileFaunaLabel.text = "Fauna: " + GameManager.Instance.gameProperties.currentTile.Fauna;
        currentTileHasCityLabel.text = "HasCity: " + GameManager.Instance.gameProperties.currentTile.HasSettlement;
        currentTileCostToMoveLabel.text = "CostToMove: " + GameManager.Instance.gameProperties.currentTile.StaminaCost;
        
        
        nextTileBiomeLabel.text = "Biome: " + GameManager.Instance.gameProperties.nextTile.Biome;
        nextTileWeatherLabel.text = "Weather: " + GameManager.Instance.gameProperties.nextTile.WeatherCondition;
        nextTileFaunaLabel.text = "Fauna: " + GameManager.Instance.gameProperties.nextTile.Fauna;
        nextTileHasCityLabel.text = "HasCity: " + GameManager.Instance.gameProperties.nextTile.HasSettlement;
        nextTileCostToMoveLabel.text = "CostToMove: " + GameManager.Instance.gameProperties.nextTile.StaminaCost;
    }
}
