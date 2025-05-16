namespace Schedule1ConsoleApp.Model;

public class Glowing : IEffect
{
    public string Name()
    {
        return "Glowing";
    }

    public string Description()
    {
        return "Causes user to have a radioactive glow.";
    }

    public decimal Multiplier()
    {
        return 0.48m;
    }

    public IEffectType Type()
    {
        return new Cosmetic();
    }
}
