namespace Schedule1ConsoleApp.Model;

public class Shrinking : IEffect
{
    public string Name()
    {
        return "Shrinking";
    }

    public string Description()
    {
        return "Causes user to shrink.";
    }

    public decimal Multiplier()
    {
        return 0.20m;
    }

    public IEffectType Type()
    {
        return new Cosmetic();
    }
}
