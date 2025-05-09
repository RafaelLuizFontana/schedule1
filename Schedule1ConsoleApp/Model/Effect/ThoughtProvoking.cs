using System;

namespace Schedule1ConsoleApp.Model;

public class ThoughtProvoking : IEffect
{
    public string Name()
    {
        return "Thought-Provoking";
    }

    public string Description()
    {
        return "Causes user's head to grow in size.";
    }

    public decimal Multiplier()
    {
        return 0.44m;
    }

    public IEffectType Type()
    {
        return new Cosmetic();
    }
}
