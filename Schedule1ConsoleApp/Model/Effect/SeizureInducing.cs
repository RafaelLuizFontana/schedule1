namespace Schedule1ConsoleApp.Model;

public class SeizureInducing : IEffect
{
    public string Name()
    {
        return "Seizure-Inducing";
    }

    public string Description()
    {
        return "Causes user to have a seizure and shake on the ground.";
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
