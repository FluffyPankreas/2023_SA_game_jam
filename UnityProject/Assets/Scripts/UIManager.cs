using DarkMushroomGames.Architecture;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviourSingleton<UIManager>
{
    [SerializeField]
    private TextMeshProUGUI foodLabel;
    
    [SerializeField]
    public TextMeshProUGUI waterLabel;
    
    [SerializeField]
    public TextMeshProUGUI woodLabel;

    [SerializeField] 
    public TextMeshProUGUI debugPhasesLabel;
    
    public void Update()
    {
        foodLabel.text = "Food: " + GameManager.Instance.playerResources.food;
        waterLabel.text = "Water: " + GameManager.Instance.playerResources.water;
        woodLabel.text = "Wood: " + GameManager.Instance.playerResources.wood;

        debugPhasesLabel.text = GameManager.Instance.currentPhase.ToString();
    }
}
