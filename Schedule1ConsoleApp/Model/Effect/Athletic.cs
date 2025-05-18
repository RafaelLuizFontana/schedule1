namespace Schedule1ConsoleApp.Model;

public class Athletic :IEffect
{
    public string Name()
    {
        return "Athletic";
    }

    public string Description()
    {
        return "Causes user to run 30% faster.";
    }

    public decimal Multiplier()
    {
        return 0.32m;
    }

    public IEffectType Type()
    {
        return new Ability();
    }
}
