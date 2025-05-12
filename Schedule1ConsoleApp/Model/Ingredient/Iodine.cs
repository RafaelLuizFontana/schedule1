using Schedule1ConsoleApp.Model.Drug;
using Schedule1ConsoleApp.Model.Interface;

namespace Schedule1ConsoleApp.Model.Ingredient;

public class Iodine : IIngredient
{
    public string Name()
    {
        return "Iodine";
    }

    public IEffect BaseEffect()
    {
        return new Jennerising();
    }

    public decimal Cost(){
        return 8.0m;
    }

    public GenericMix Mix(IBaseDrug drug){
        GenericMix genericMix;
        if (drug is GenericMix mix)
        {
            genericMix = mix;
        } else {
            genericMix = new(drug);
        }
        EffectList effects = genericMix.Effects();
        foreach(EffectListItem effect in  effects.GetEffects()){
            switch(effect.Effect){
                case Calming calming:
                    effects.SetEffect(calming, false);
                    effects.SetEffect(new Balding());
                    break;
                case CalorieDense calorieDense:
                    effects.SetEffect(calorieDense, false);
                    effects.SetEffect(new Gingeritis());
                    break;
                case Euphoric euphoric:
                    effects.SetEffect(euphoric, false);
                    effects.SetEffect(new SeizureInducing());
                    break;
                case Foggy foggy:
                    effects.SetEffect(foggy, false);
                    effects.SetEffect(new Paranoia());
                    break;
                case Refreshing refreshing:
                    effects.SetEffect(refreshing, false);
                    effects.SetEffect(new ThoughtProvoking());
                    break;
                case Toxic toxic:
                    effects.SetEffect(toxic, false);
                    effects.SetEffect(new Sneaky());
                    break;
                default:
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
