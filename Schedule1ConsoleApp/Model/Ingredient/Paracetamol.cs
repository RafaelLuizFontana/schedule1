namespace Schedule1ConsoleApp.Model.Ingredient;

public class Paracetamol : IIngredient
{
    public string Name()
    {
        return "Paracetamol";
    }

    public IEffect BaseEffect()
    {
        return new Sneaky();
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
