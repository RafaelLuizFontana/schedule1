using Schedule1ConsoleApp.Model.DrugType;
using Schedule1ConsoleApp.Model.Effect;
using Schedule1ConsoleApp.Model.Interface;

namespace Schedule1ConsoleApp.Model.Drug;

public class Coke : IBaseDrug
{
    public string Name()
    {
        return "Cocaine";
    }

    public IDrugType Type()
    {
        return new Cocaine();
    }

    public IEffect BaseEffect()
    {
        return new None();
    }

    public decimal BaseValue()
    {
        return 150.0m;
    }
}
