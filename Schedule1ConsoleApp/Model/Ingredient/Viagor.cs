namespace Schedule1ConsoleApp.Model.Ingredient;

public class Viagor : IIngredient
{
    public string Name()
    {
        return "Viagor";
    }

    public IEffect BaseEffect()
    {
        return new TropicThunder();
    }

    public decimal Cost(){
        return 4.0m;
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
