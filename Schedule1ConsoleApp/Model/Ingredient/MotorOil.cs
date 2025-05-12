using Schedule1ConsoleApp.Model.Drug;
using Schedule1ConsoleApp.Model.Interface;

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
                case Energizing energizing:
                    effects.SetEffect(energizing, false);
                    effects.SetEffect(new Munchies());
                    break;
                case Euphoric euphoric:
                    effects.SetEffect(euphoric, false);
                    effects.SetEffect(new Sedating());
                    break;
                case Foggy foggy:
                    effects.SetEffect(foggy, false);
                    effects.SetEffect(new Toxic());
                    break;
                case Munchies munchies:
                    if(!effects.HasEffect(new Energizing())){
                        effects.SetEffect(munchies, false);
                        effects.SetEffect(new Schizophrenic());
                    }
                    break;
                case Paranoia paranoia:
                    effects.SetEffect(paranoia, false);
                    effects.SetEffect(new AntiGravity());
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
