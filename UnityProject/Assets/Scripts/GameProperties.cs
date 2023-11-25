using System.Collections.Generic;
using UnityEngine;

public class GameProperties : MonoBehaviour
{
    
    private List<Tile> _tiles;

    public int currentDay;
    public int babaYagaTileIndex; 
    public int playerTileIndex;
    public Tile currentTile => _tiles[playerTileIndex];
    public Tile nextTile => _tiles[^1];
    
    public void Start()
    {
        _tiles = new List<Tile>();
    }

    public void GenerateNewTile()
    {
        _tiles.Add( new Tile());
        
        var tileString = "";
        foreach (var tile in _tiles)
        {
            tileString += tile.Biome;
            tileString += " -> ";
        }
        Debug.Log(tileString);
    }
}
