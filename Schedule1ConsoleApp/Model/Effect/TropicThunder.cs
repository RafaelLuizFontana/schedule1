using System;

namespace Schedule1ConsoleApp.Model;

public class TropicThunder : IEffect
{
    public string Name()
    {
        return "Tropic Thunder";
    }

    public string Description()
    {
        return "Causes user's skin color to invert from light to dark or dark to light.";
    }

    public decimal Multiplier()
    {
        return 0.46m;
    }

    public IEffectType Type()
    {
        return new Cosmetic();
    }
}
