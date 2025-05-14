using System;

namespace Schedule1ConsoleApp.Model;

public class Toxic : IEffect
{
    public string Name()
    {
        return "Toxic";
    }

    public string Description()
    {
        return "Causes user to vomit.";
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
