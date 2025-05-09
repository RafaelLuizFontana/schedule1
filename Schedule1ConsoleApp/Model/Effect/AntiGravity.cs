using System;

namespace Schedule1ConsoleApp.Model;

public class AntiGravity : IEffect
{
    public string Name()
    {
        return "Anti-Gravity";
    }

    public string Description()
    {
        return "Causes user to jump higher.";
    }

    public decimal Multiplier()
    {
        return 0.54m;
    }

    public IEffectType Type()
    {
        return new Ability();
    }
}
