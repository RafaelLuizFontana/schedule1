using System;

namespace Schedule1ConsoleApp.Model;

public class Slippery : IEffect
{
    public string Name()
    {
        return "Slippery";
    }

    public string Description()
    {
        return "Causes user to have sluggish, slippery movement.";
    }

    public decimal Multiplier()
    {
        return 0.34m;
    }

    public IEffectType Type()
    {
        return new Ability();
    }
}
