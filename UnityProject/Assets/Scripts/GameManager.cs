using System.Collections.Generic;
using DarkMushroomGames.Architecture;
using UnityEngine;

public class GameManager : MonoBehaviourSingleton<GameManager>
{
    [SerializeField,Tooltip("Reference to the player resources script.")]
    private Resources playerResources;
    [SerializeField,Tooltip("Reference to the player attributes script.")]
    private Attributes playerAttributes;
    
    private List<PlayerAction> morningActions;
    private List<PlayerAction> afternoonActions;
    private List<PlayerAction> eveningActions;
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
        //Setup the UI to show the actions
    }

    /// <summary>
    /// Selects a subset of actions from the list and returns the subset.
    /// </summary>
    /// <param name="allActions">All the actions to choose a subset from.</param>
    private List<PlayerAction> SelectActions(List<PlayerAction> allActions)
    {
        //TODO: Implement the selection.
        return allActions;
    }

}
