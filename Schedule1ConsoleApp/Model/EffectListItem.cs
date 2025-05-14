namespace Schedule1ConsoleApp.Model;

public class EffectListItem(IEffect effect, bool isPresent = false)
{
    public IEffect Effect { get; set; } = effect;
    public bool IsPresent { get; set; } = isPresent;
}
