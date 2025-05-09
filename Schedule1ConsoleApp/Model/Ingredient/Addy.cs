namespace Schedule1ConsoleApp.Model.Ingredient;

public class Addy : IIngredient
{
    public string Name()
    {
        return "Addy";
    }

    public IEffect BaseEffect()
    {
        return new ThoughtProvoking();
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
