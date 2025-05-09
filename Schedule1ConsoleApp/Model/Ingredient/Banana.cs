using System;

namespace Schedule1ConsoleApp.Model.Ingredient;

public class Banana : IIngredient
{
    public string Name()
    {
        return "Banana";
    }

    public IEffect BaseEffect()
    {
        return new Gingeritis();
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
