using System;

namespace Schedule1ConsoleApp.Model;

public class Balding : IEffect
{
    public string Name()
    {
        return "Balding";
    }

    public string Description()
    {
        return "Causes user to be bald.";
    }

    public decimal Multiplier()
    {
        return 0.30m;
    }

    public IEffectType Type()
    {
        return new Cosmetic();
    }
}
