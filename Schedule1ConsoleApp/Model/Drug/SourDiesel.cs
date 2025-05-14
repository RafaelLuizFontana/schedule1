using Schedule1ConsoleApp.Model.DrugType;
using Schedule1ConsoleApp.Model.Interface;

namespace Schedule1ConsoleApp.Model.Drug;

public class SourDiesel : IBaseDrug
{

    public string Name()
    {
        return "Sour Diesel";
    }

    public IDrugType Type()
    {
        return new Marijuana();
    }

    public IEffect BaseEffect()
    {
        return new Refreshing();
    }

    public decimal BaseValue()
    {
        return 40.0m;
    }
}
