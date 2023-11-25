using UnityEngine;

public enum Biomes
{
    Desert,
    Forest,
    Mountains,
    Plains
}

public enum WeatherConditions
{
    Clear,
    Raining,
}

public enum FaunaTypes
{
    None,
    Docile,
    Dangerous
}


public class Tile
{
    public Biomes Biome;
    public WeatherConditions WeatherCondition;
    public FaunaTypes Fauna;
    public bool HasCity;
    
    public int StaminaCost;

    public Tile()
    {
        RandomizeBiome();
        SetStaminaCost();
        SetWeatherCondition();
        SetFauna();
        SetCity();
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

    private void SetWeatherCondition()
    {
        //TODO: set the weather condition. Random chances based on the terrain type.
    }

    private void SetFauna()
    {
        //TODO: Set the fauna type. Random chances based on the terrain type.
    }

    private void SetCity()
    {
        
    }
}