using System;

namespace Schedule1ConsoleApp.Model;

public class Foggy : IEffect
{
    public string Name()
    {
        return "Foggy";
    }

    public string Description()
    {
        return "Causes a fog cloud effect around user. Also causes a global fog effect, significantly limiting visibility.";
    }

    public decimal Multiplier()
    {
        return 0.36m;
    }

    public IEffectType Type()
    {
        return new Cosmetic();
    }
}
