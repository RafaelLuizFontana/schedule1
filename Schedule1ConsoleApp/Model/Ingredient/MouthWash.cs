using System;
using Schedule1ConsoleApp.Model.Drug;
using Schedule1ConsoleApp.Model.Interface;

namespace Schedule1ConsoleApp.Model.Ingredient;

public class MouthWash : IIngredient
{
    public string Name()
    {
        return "Mouth Wash";
    }

    public IEffect BaseEffect()
    {
        return new Balding();
    }

    public decimal Cost(){
        return 4.0m;
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
                    effects.SetEffect(new AntiGravity());
                    break;
                case CalorieDense calorieDense:
                    effects.SetEffect(calorieDense, false);
                    effects.SetEffect(new Sneaky());
                    break;
                case Explosive explosive:
                    effects.SetEffect(explosive, false);
                    effects.SetEffect(new Sedating());
                    break;
                case Focused focused:
                    effects.SetEffect(focused, false);
                    effects.SetEffect(new Jennerising());
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
