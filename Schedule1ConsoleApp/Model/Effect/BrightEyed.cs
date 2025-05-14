using System;

namespace Schedule1ConsoleApp.Model;

public class BrightEyed : IEffect
{
    public string Name()
    {
        return "Bright-Eyed";
    }

    public string Description()
    {
        return "Causes user's eyes to shine flashlight beams.";
    }

    public decimal Multiplier()
    {
        return 0.40m;
    }

    public IEffectType Type()
    {
        return new Ability();
    }
}
