using System;

namespace Schedule1ConsoleApp.Model;

public class Jennerising : IEffect
{
    public string Name()
    {
        return "Jennerising";
    }

    public string Description()
    {
        return "Causes user to appear female.";
    }

    public decimal Multiplier()
    {
        return 0.42m;
    }

    public IEffectType Type()
    {
        return new Cosmetic();
    }
}
