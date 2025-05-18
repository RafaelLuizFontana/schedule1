namespace Schedule1ConsoleApp.Model;

public class Schizophrenic : IEffect
{
    public string Name()
    {
        return "Schizophrenic";
    }

    public string Description()
    {
        return "Causes user to run backwards while saying \"oh no\" (muffled) and hear muffled voices. Loud heart beat, open mouth frown, and squinting eyes. User's vision will also randomly pulse.";
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
