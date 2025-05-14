using System;

namespace Schedule1ConsoleApp.Model;

public class Refreshing : IEffect
{
    public string Name()
    {
        return "Refreshing";
    }

    public string Description()
    {
        return "";
    }

    public decimal Multiplier()
    {
        return 0.14m;
    }

    public IEffectType Type()
    {
        return new Untyped();
    }
}
