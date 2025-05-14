using System;

namespace Schedule1ConsoleApp.Model;

public class Focused : IEffect
{
    public string Name()
    {
        return "Focused";
    }

    public string Description()
    {
        return "Causes user to have chromatic aberration around screen.";
    }

    public decimal Multiplier()
    {
        return 0.16m;
    }

    public IEffectType Type()
    {
        return new Cosmetic();
    }
}
