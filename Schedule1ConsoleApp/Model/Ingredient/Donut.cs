using Schedule1ConsoleApp.Model.Drug;

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

    public decimal Cost(){
        return 3.0m;
    }

    public GenericMix Mix(GenericMix genericMix){
        EffectList effects = genericMix.Effects();
        foreach(EffectListItem effect in  effects.GetEffects()){
            switch(effect.Effect){
                case AntiGravity antiGravity:
                    effects.SetEffect(antiGravity, false);
                    effects.SetEffect(new CalorieDense());
                    effects.SetEffect(new Slippery());
                    break;
                case Balding balding:
                    effects.SetEffect(balding, false);
                    effects.SetEffect(new CalorieDense());
                    effects.SetEffect(new Sneaky());
                    break;
                case CalorieDense calorieDense:
                    if(!effects.HasEffect(new Explosive())){
                        effects.SetEffect(calorieDense, false);
                        effects.SetEffect(new Explosive());
                    }
                    break;
                case Focused focused:
                    effects.SetEffect(focused, false);
                    effects.SetEffect(new CalorieDense());
                    effects.SetEffect(new Euphoric());
                    break;
                case Jennerising jennerising:
                    effects.SetEffect(jennerising, false);
                    effects.SetEffect(new CalorieDense());
                    effects.SetEffect(new Gingeritis());
                    break;
                case Munchies munchies:
                    effects.SetEffect(munchies, false);
                    effects.SetEffect(new CalorieDense());
                    effects.SetEffect(new Calming());
                    break;
                case Shrinking shrinking:
                    effects.SetEffect(shrinking, false);
                    effects.SetEffect(new CalorieDense());
                    effects.SetEffect(new Energizing());
                    break;
                default:
                    effects.SetEffect(new CalorieDense());
                    break;
            }
        }
        return genericMix;
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
