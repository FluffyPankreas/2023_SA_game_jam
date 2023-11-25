using DarkMushroomGames.Architecture;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class UIManager : MonoBehaviourSingleton<UIManager>
{
    [Header("Player Information")]
    [SerializeField]
    private TextMeshProUGUI foodLabel;
    
    [SerializeField]
    private TextMeshProUGUI waterLabel;
    
    [SerializeField]
    private TextMeshProUGUI woodLabel;

    [Header("Game Information")]
    [SerializeField] 
    private TextMeshProUGUI phasesLabel;

    [Header("Current Tile")]
    [SerializeField]
    private TextMeshProUGUI currentTileBiomeLabel;
    
    [Header("Next Tile")]
    [SerializeField]
    private TextMeshProUGUI nextTileBiomeLabel;
    
    public void Update()
    {
        foodLabel.text = "Food: " + GameManager.Instance.playerResources.food;
        waterLabel.text = "Water: " + GameManager.Instance.playerResources.water;
        woodLabel.text = "Wood: " + GameManager.Instance.playerResources.wood;

        phasesLabel.text = GameManager.Instance.currentPhase.ToString();

        currentTileBiomeLabel.text = "Biome: " + GameManager.Instance.gameProperties.currentTile.Biome;
        nextTileBiomeLabel.text = "Biome: " + GameManager.Instance.gameProperties.nextTile.Biome;
    }
}
