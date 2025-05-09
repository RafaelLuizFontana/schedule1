namespace Schedule1ConsoleApp.Model.Ingredient;

public class HorseSemen : IIngredient
{
    public string Name()
    {
        return "Horse Semen";
    }

    public IEffect BaseEffect()
    {
        return new LongFaced();
    }

    public override int GetHashCode() {
        return 0;
    }
    
    public override bool Equals(object? obj) {
        if (obj == null || GetType() != obj.GetType()) return false;
        var other = (IIngredient)obj;
        return Name() == other.Name() && BaseEffect().GetHashCode() == other.BaseEffect().GetHashCode();
    }
}
