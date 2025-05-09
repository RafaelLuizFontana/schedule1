using System;

namespace Schedule1ConsoleApp.Model;

public class Munchies : IEffect
{
    public string Name()
    {
        return "Munchies";
    }

    public string Description()
    {
        return "";
    }

    public decimal Multiplier()
    {
        return 0.12m;
    }

    public IEffectType Type()
    {
        return new Untyped();
    }
}
