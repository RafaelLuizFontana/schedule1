namespace Schedule1ConsoleApp.Model;

public class Sneaky : IEffect
{
    public string Name()
    {
        return "Sneaky";
    }

    public string Description()
    {
        return "Causes the police \"?\" meter to fill up half as fast, and increases size of pickpocket success areas.";
    }

    public decimal Multiplier()
    {
        return 0.24m;
    }

    public IEffectType Type()
    {
        return new Ability();
    }
}
