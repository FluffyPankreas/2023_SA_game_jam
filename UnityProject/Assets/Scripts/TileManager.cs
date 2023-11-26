using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public TileRuntimeObject tilePrefab;
    public float scaleSpeed = 0.015f;
    private TileRuntimeObject _nextTile;
    private TileRuntimeObject _currentTile;
    private TileRuntimeObject _previousTile;

    public void Awake()
    {
        _nextTile = null;
        _previousTile = null;
        _currentTile = null;
    }
    // shows the current, previous, and next tile
    public void CreateTile(Tile newTile)
    {
        var newRuntimeTile = Instantiate(tilePrefab, transform);
        newRuntimeTile.SetTerrainType((int)newTile.Biome);

        if (_previousTile != null)
        {
            Destroy(_previousTile.gameObject);
        }

        _previousTile = _currentTile;
        _currentTile = _nextTile;
        _nextTile = newRuntimeTile;
        
        

        if (_nextTile != null)
        {
            _nextTile.transform.position = new Vector3(0, 0, 70);
            _nextTile.SetNewTargetPosition(35);
        }

        if (_currentTile != null)
        {
            _currentTile.SetNewTargetPosition(0);
        }
        else if (_nextTile != null)
        {
            _nextTile.transform.position = new Vector3(0, 0, 35);
        }

        if (_previousTile != null)
        {
            _previousTile.SetNewTargetPosition(-35);
        }
        else if(_currentTile != null)
        {
            _currentTile.transform.position = new Vector3(0, 0, 0);
        }

        newRuntimeTile.gameObject.SetActive(true);
    }
}
