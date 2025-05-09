namespace Schedule1ConsoleApp.Model.Effect;

public class None : IEffect
{
    public string Name()
    {
        return "";
    }

    public string Description()
    {
        return "";
    }

    public decimal Multiplier()
    {
        return 0.0m;
    }

    public IEffectType Type()
    {
        return new Untyped();
    }
}

