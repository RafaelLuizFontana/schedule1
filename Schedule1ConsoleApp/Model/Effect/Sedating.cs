namespace Schedule1ConsoleApp.Model;

public class Sedating : IEffect
{
    public string Name()
    {
        return "Sedating";
    }

    public string Description()
    {
        return "Causes user to have a vignette around screen and mouse smoothing.";
    }

    public decimal Multiplier()
    {
        return 0.26m;
    }

    public IEffectType Type()
    {
        return new Cosmetic();
    }
}
