using Schedule1ConsoleApp.Model.DrugType;
using Schedule1ConsoleApp.Model.Effect;
using Schedule1ConsoleApp.Model.Interface;

namespace Schedule1ConsoleApp.Model.Drug;

public class Meth : IBaseDrug
{
    public string Name()
    {
        return "Methamphetamine";
    }

    public IDrugType Type()
    {
        return new Methamphetamine();
    }

    public IEffect BaseEffect()
    {
        return new None();
    }

    public decimal BaseValue()
    {
        return 70.0m;
    }
}
