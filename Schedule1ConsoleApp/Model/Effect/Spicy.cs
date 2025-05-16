namespace Schedule1ConsoleApp.Model;

public class Spicy : IEffect
{
    public string Name()
    {
        return "Spicy";
    }

    public string Description()
    {
        return "Causes user's head to light on fire.";
    }

    public decimal Multiplier()
    {
        return 0.38m;
    }

    public IEffectType Type()
    {
        return new Cosmetic();
    }
}
