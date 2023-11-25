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
    Storm,
    Overcast,
    Snow
}

public enum FaunaTypes
{
    None,
    Docile,
    Predator,
    Poisonous,
    Dangerous
}

public class Tile
{
    public Biomes Biome;
    public WeatherConditions WeatherCondition;
    public FaunaTypes Fauna;
    public bool HasSettlement;
    
    public int StaminaCost;

    public Tile()
    {
        RandomizeBiome();
        SetStaminaCost();
        SetWeatherCondition();
        SetFauna();
        SetSettlements();
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
        WeatherCondition = (WeatherConditions)Random.Range(0, 2);
    }

    private void SetFauna()
    {
        //TODO: Set the fauna type. Random chances based on the terrain type.
        Fauna = (FaunaTypes)Random.Range((int)FaunaTypes.None, (int)FaunaTypes.Dangerous);
    }

    private void SetSettlements()
    {
        HasSettlement = Random.Range(0, 10) > 5;
    }
}