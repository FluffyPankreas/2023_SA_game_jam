using System;
using System.Collections.Generic;
using DarkMushroomGames.Architecture;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviourSingleton<GameManager>
{
    [SerializeField,Tooltip("Reference to the player resources script.")]
    private Resources playerResources;
    [SerializeField,Tooltip("Reference to the player attributes script.")]
    private Attributes playerAttributes;
    
    [SerializeField,Tooltip("The list of potential actions the player can take in the morning.")]
    private List<PlayerAction> morningActions;
    
    public void StartOfDay()
    {
        
    }

    public void EndOfDay()
    {
        //subtract water/food 
        //
        
    }

    private void SelectMorningActions()
    {
        
    }

    private void SelectAfternoonActions()
    {
        
    }

    private void SelectEveningActions()
    {
        
    }
}
