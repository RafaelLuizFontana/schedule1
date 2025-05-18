namespace Schedule1ConsoleApp.Model;

public class Electrifying : IEffect
{
    public int ID(){
        return 9;
    }
    
    public string Name()
    {
        return "Electrifying";
    }

    public string Description()
    {
        return "Causes lightning effect on user.";
    }

    public decimal Multiplier()
    {
        return 0.50m;
    }

    public IEffectType Type()
    {
        return new Cosmetic();
    }
}
