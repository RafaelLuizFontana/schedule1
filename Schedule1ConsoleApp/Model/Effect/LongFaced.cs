namespace Schedule1ConsoleApp.Model;

public class LongFaced : IEffect
{
    public string Name()
    {
        return "Long Faced";
    }

    public string Description()
    {
        return "Causes user's neck and face to grow.";
    }

    public decimal Multiplier()
    {
        return 0.52m;
    }

    public IEffectType Type()
    {
        return new Cosmetic();
    }
}
