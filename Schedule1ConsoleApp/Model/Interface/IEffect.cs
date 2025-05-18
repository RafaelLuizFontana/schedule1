namespace Schedule1ConsoleApp.Model;

public interface IEffect
{
    string Name();
    decimal Multiplier();
    IEffectType Type();
    string Description();
}
