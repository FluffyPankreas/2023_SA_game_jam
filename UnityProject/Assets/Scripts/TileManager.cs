using UnityEngine;

public class TileManager : MonoBehaviour
{
    public TileRuntimeObject tilePrefab;
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
        newRuntimeTile.gameObject.SetActive(true);
    }

}
