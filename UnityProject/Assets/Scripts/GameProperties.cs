using System.Collections.Generic;
using UnityEngine;

public class GameProperties : MonoBehaviour
{
    
    private List<Tile> _tiles;

    public int currentDay;
    public int babaYagaDistance;// How many tiles the baba yaga is away from the player. 
    public int currentTileNumber => _tiles.Count;
    public Tile currentTile => _tiles[^2];
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
