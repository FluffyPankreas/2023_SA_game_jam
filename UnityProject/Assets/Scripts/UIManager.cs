using DarkMushroomGames.Architecture;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviourSingleton<UIManager>
{
    [SerializeField]
    private TextMeshProUGUI foodLabel;
    
    [SerializeField]
    public TextMeshProUGUI waterLabel;

    public void Update()
    {
        foodLabel.text = "Food: " + GameManager.Instance.playerResources.food;
        waterLabel.text = "Water: " + GameManager.Instance.playerResources.water;
    }
}
