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
        GenerateNewTile();// Always start with one tile.
    }

    public void GenerateNewTile()
    {
        _tiles.Add( new Tile());
    }
}
