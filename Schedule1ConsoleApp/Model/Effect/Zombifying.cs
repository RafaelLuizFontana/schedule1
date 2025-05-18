namespace Schedule1ConsoleApp.Model;

public class Zombifying : IEffect
{
    public string Name()
    {
        return "Zombifying";
    }

    public string Description()
    {
        return "Causes user to have green skin and have a zombie-like voice.";
    }

    public decimal Multiplier()
    {
        return 0.58m;
    }

    public IEffectType Type()
    {
        return new Cosmetic();
    }
}
