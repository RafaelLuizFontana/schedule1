using Schedule1ConsoleApp.Model.Drug;
using Schedule1ConsoleApp.Model.Interface;

namespace Schedule1ConsoleApp.Model;

public interface IIngredient
{
    public string Name();
    public IEffect BaseEffect();
    public decimal Cost();
    public GenericMix Mix(IBaseDrug drug);
}
