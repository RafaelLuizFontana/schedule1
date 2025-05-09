using System;

namespace Schedule1ConsoleApp.Model;

public class Laxative : IEffect
{
    public string Name()
    {
        return "Laxative";
    }

    public string Description()
    {
        return "Causes user to constantly soil themselves.";
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
