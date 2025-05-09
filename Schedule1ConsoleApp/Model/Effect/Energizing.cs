using System;

namespace Schedule1ConsoleApp.Model;

public class Energizing : IEffect
{
    public string Name()
    {
        return "Energizing";
    }

    public string Description()
    {
        return "Causes user to run 15% faster.";
    }

    public decimal Multiplier()
    {
        return 0.22m;
    }

    public IEffectType Type()
    {
        return new Ability();
    }
}
