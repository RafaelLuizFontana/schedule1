namespace Schedule1ConsoleApp.Model;

public class Smelly : IEffect
{
    public string Name()
    {
        return "Smelly";
    }

    public string Description()
    {
        return "Causes user to have a stinky cloud around them.";
    }

    public decimal Multiplier()
    {
        return 0.00m;
    }

    public IEffectType Type()
    {
        return new Cosmetic();
    }
}
