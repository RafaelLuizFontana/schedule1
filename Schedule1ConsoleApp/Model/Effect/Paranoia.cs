using System;

namespace Schedule1ConsoleApp.Model;

public class Paranoia : IEffect
{
    public string Name()
    {
        return "Paranoia";
    }

    public string Description()
    {
        return "Causes user to have a bad high. Also makes NPCs appear to stare at the user from long distances.";
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
