namespace Schedule1ConsoleApp.Model;

public class Gingeritis : IEffect
{
    public string Name()
    {
        return "Gingeritis";
    }

    public string Description()
    {
        return "Causes user to have red hair.";
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
