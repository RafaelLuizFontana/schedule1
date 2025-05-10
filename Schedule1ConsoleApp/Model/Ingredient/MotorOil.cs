namespace Schedule1ConsoleApp.Model.Ingredient;

public class MotorOil : IIngredient
{
    public string Name()
    {
        return "Motor Oil";
    }

    public IEffect BaseEffect()
    {
        return new Slippery();
    }

    public decimal Cost(){
        return 6.0m;
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
