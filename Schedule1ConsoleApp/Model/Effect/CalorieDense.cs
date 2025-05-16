namespace Schedule1ConsoleApp.Model;

public class CalorieDense : IEffect
{
    public string Name()
    {
        return "Calorie-Dense";
    }

    public string Description()
    {
        return "Causes user to appear fat.";
    }

    public decimal Multiplier()
    {
        return 0.28m;
    }

    public IEffectType Type()
    {
        return new Cosmetic();
    }
}
