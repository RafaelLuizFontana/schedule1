namespace Schedule1ConsoleApp.Model;

public class Calming : IEffect
{
    public string Name()
    {
        return "Calming";
    }

    public string Description()
    {
        return "Causes user to have chromatic aberration around screen.";
    }

    public decimal Multiplier()
    {
        return 0.10m;
    }

    public IEffectType Type()
    {
        return new Cosmetic();
    }
}
