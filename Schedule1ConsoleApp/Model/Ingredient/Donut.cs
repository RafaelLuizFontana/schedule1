namespace Schedule1ConsoleApp.Model.Ingredient;

public class Donut : IIngredient
{
    public string Name()
    {
        return "Donut";
    }

    public IEffect BaseEffect()
    {
        return new CalorieDense();
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
