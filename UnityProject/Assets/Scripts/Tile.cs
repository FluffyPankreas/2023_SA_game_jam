using UnityEngine;

public enum Biomes
{
    Desert,
    Forest,
    Mountains,
    Plains,
    Swamp
}

public enum WeatherConditions
{
    Clear,
    Raining,
    Fog,
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
    
    public int TravelCost;

    public Tile()
    {
        RandomizeBiome();
        SetTravelCost();
        SetWeatherCondition();
        SetFauna();
        SetSettlements();
    }
    
    private void RandomizeBiome()
    {
         Biome = (Biomes)Random.Range(0, 5);
    }

    private void SetTravelCost()
    {
        switch (Biome)
        {
            case Biomes.Desert:
                TravelCost = Random.Range(1, 5);
                break;
            case Biomes.Forest:
                TravelCost = Random.Range(2, 4) ;
                break;
            case Biomes.Mountains:
                TravelCost = Random.Range(1, 8);
                break;
            case Biomes.Plains:
                TravelCost = Random.Range(1, 2);
                break;
            case Biomes.Swamp:
                TravelCost = Random.Range(1, 2);
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