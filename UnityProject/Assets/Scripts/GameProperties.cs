using System.Collections.Generic;
using UnityEngine;

public class GameProperties : MonoBehaviour
{
    public enum Biomes
    {
        Desert,
        Forest,
        Mountains,
        Plains
    }

    public int currentDay;
    public int tileNumber;

    public Biomes currentBiome;
    // animals
    // weather
    // baba yaga distance

    public void GenerateNewTile()
    {
        SelectBiome();
    }
    
    private void SelectBiome()
    {
        currentBiome = (Biomes)Random.Range(0, 4);
        Debug.Log("New biome: " + currentBiome.ToString());
    }

}
