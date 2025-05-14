using Schedule1ConsoleApp.Model.DrugType;
using Schedule1ConsoleApp.Model.Interface;

namespace Schedule1ConsoleApp.Model.Drug;

public class OGKush : IBaseDrug
{
    public string Name()
    {
        return "OG Kush";
    }

    public IDrugType Type()
    {
        return new Marijuana();
    }

    public IEffect BaseEffect()
    {
        return new Calming();
    }

    public decimal BaseValue()
    {
        return 38.0m;
    }
}
