namespace Schedule1ConsoleApp.Model.Ingredient;

public class MegaBean : IIngredient
{
    public string Name()
    {
        return "Mega Bean";
    }

    public IEffect BaseEffect()
    {
        return new Foggy();
    }

    public decimal Cost(){
        return 7.0m;
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
