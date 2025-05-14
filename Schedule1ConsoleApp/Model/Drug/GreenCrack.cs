using Schedule1ConsoleApp.Model.DrugType;
using Schedule1ConsoleApp.Model.Interface;

namespace Schedule1ConsoleApp.Model.Drug;

public class GreenCrack : IBaseDrug
{

    public string Name()
    {
        return "Green Crack";
    }

    public IDrugType Type()
    {
        return new Marijuana();
    }

    public IEffect BaseEffect()
    {
        return new Energizing();
    }

    public decimal BaseValue()
    {
        return 43.0m;
    }
}
