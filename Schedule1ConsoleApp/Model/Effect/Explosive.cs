namespace Schedule1ConsoleApp.Model;

public class Explosive : IEffect
{
    public string Name()
    {
        return "Explosive";
    }

    public string Description()
    {
        return "Causes user to explode after ticking countdown, killing the user and damaging NPCs in the vicinity.";
    }

    public decimal Multiplier()
    {
        return 0.00m;
    }

    public IEffectType Type()
    {
        return new Ability();
    }
}