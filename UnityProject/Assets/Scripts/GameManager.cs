using System.Collections.Generic;
using DarkMushroomGames.Architecture;
using PlayerActions;
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

    private List<PlayerAction> morningActions;
    private List<PlayerAction> afternoonActions;
    private List<PlayerAction> eveningActions;

    // Building actions should be added
    // Location actions

    public void Start()
    {
        DisplayActions(new List<PlayerAction>());
    }

    public void StartOfDay()
    {
        // Start of day -> Morning action -> Afternoon Action -> Evening Action -> End of Day
    }

    public void EndOfDay()
    {
        // Do end of day calculations and see if the player loses.
    }

    private void DisplayActions(List<PlayerAction> actionsToShow)
    {
        Debug.Log("Displaying Actions.");
        //Setup the UI to show the actions
        var button = Instantiate(playerActionButtonPrefab, buttonLayoutParent);
        
        var newAction = new PlayerAction();
        button.GetComponent<Button>().onClick.AddListener(newAction.CalculateResult);
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
            Debug.Log("i: " + i.ToString());

            selectedActions = new List<PlayerAction>();
        }

        return selectedActions;
    }
}
