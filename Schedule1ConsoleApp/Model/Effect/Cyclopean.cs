using System;

namespace Schedule1ConsoleApp.Model;

public class Cyclopean : IEffect
{
    public string Name()
    {
        return "Cyclopean";
    }

    public string Description()
    {
        return "Causes user to only have one eye.";
    }

    public decimal Multiplier()
    {
        return 0.56m;
    }

    public IEffectType Type()
    {
        return new Cosmetic();
    }
}
