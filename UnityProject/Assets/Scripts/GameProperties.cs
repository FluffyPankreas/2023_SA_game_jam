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
    
    public void Awake()
    {
        _tiles = new List<Tile>();
    }

    public Tile GenerateNewTile()
    {
        var newTile = new Tile();
        _tiles.Add(new Tile());
        
        return newTile;
    }
}
