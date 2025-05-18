namespace Schedule1ConsoleApp.Model;

public class Disorienting : IEffect
{
    public string Name()
    {
        return "Disorienting";
    }

    public string Description()
    {
        return "Causes camera controls for up/down, and movement controls for left/right to be inverted. Forward/backward movement controls will also invert at random for a few steps.";
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
