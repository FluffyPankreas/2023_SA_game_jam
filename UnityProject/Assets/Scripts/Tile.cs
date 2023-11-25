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
    public int StaminaCost;

    public Tile()
    {
        RandomizeBiome();
        
    }
    
    private void RandomizeBiome()
    {
         Biome = (Biomes)Random.Range(0, 4);
    }

    private void SetStaminaCost()
    {
        switch (Biome)
        {
            case Biomes.Desert:
                StaminaCost = Random.Range(1, 5);
                break;
            case Biomes.Forest:
                StaminaCost = Random.Range(2, 4) ;
                break;
            case Biomes.Mountains:
                StaminaCost = Random.Range(1, 8);
                break;
            case Biomes.Plains:
                StaminaCost = Random.Range(1, 2);
                break;
        }
    }
        
    // animals
    // weather
    // has some city?
    // encounter
    // cost to move to next tile.
}