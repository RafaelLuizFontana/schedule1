namespace Schedule1ConsoleApp.Model.Ingredient;

public class FluMedicine : IIngredient
{
    public string Name()
    {
        return "Flu Medicine";
    }

    public IEffect BaseEffect()
    {
        return new Sedating();
    }

    public decimal Cost(){
        return 5.0m;
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
