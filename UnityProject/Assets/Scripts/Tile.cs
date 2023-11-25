using UnityEngine;

public enum Biomes
{
    Desert,
    Forest,
    Mountains,
    Plains
}
public class Tile
{
    public Biomes Biome;

    public Tile()
    {
        RandomizeBiome();
    }
    
    private void RandomizeBiome()
    {
         Biome = (Biomes)Random.Range(0, 4);
    }
        
    // animals
    // weather
    // has some city?
    // encounter
    // cost to move to next tile.
}