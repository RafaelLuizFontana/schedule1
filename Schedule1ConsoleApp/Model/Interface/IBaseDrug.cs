namespace Schedule1ConsoleApp.Model.Interface;

public interface IBaseDrug
{
    string Name();
    IDrugType Type();
    IEffect BaseEffect();
    decimal BaseValue();
}
