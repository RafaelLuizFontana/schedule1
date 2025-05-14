using Schedule1ConsoleApp.Model.DrugType;
using Schedule1ConsoleApp.Model.Interface;

namespace Schedule1ConsoleApp.Model.Drug;

public class GranddaddyPurple : IBaseDrug
{

    public string Name()
    {
        return "Granddaddy Purple";
    }

    public IDrugType Type()
    {
        return new Marijuana();
    }

    public IEffect BaseEffect()
    {
        return new Sedating();
    }

    public decimal BaseValue()
    {
        return 44.0m;
    }
}
