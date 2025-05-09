namespace Schedule1ConsoleApp.Model;

public class Euphoric : IEffect
{
    public string Name()
    {
        return "Euphoric";
    }

    public string Description()
    {
        return "Causes user to have a euphoric/happy high and smile.";
    }

    public decimal Multiplier()
    {
        return 0.18m;
    }

    public IEffectType Type()
    {
        return new Cosmetic();
    }
}
