namespace Schedule1ConsoleApp.Model.Ingredient;

public class Cuke : IIngredient
{
    public string Name()
    {
        return "Cuke";
    }

    public IEffect BaseEffect()
    {
        return new Energizing();
    }

    public decimal Cost(){
        return 2.0m;
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
