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
    public readonly Biomes Biome;

    public Tile()
    {
        Biome = GetRandomBiome();
    }
    
    private Biomes GetRandomBiome()
    {
        return (Biomes)Random.Range(0, 4);
    }
        
    // animals
    // weather
    // has some city?
    // encounter
    // cost to move to next tile.
}