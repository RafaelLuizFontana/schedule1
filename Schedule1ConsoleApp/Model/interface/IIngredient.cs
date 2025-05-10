namespace Schedule1ConsoleApp.Model;

public interface IIngredient
{
    public string Name();
    public IEffect BaseEffect();
    public decimal Cost();
}
