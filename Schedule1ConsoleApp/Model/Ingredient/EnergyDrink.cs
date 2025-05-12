using Schedule1ConsoleApp.Model.Drug;
using Schedule1ConsoleApp.Model.Interface;

namespace Schedule1ConsoleApp.Model.Ingredient;

public class EnergyDrink : IIngredient
{
    public string Name()
    {
        return "Energy Drink";
    }

    public IEffect BaseEffect()
    {
        return new Athletic();
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
                case Disorienting disorienting:
                    effects.SetEffect(disorienting, false);
                    effects.SetEffect(new Electrifying());
                    break;
                case Euphoric euphoric:
                    effects.SetEffect(euphoric, false);
                    effects.SetEffect(new Energizing());
                    break;
                case Focused focused:
                    effects.SetEffect(focused, false);
                    effects.SetEffect(new Shrinking());
                    break;
                case Foggy foggy:
                    effects.SetEffect(foggy, false);
                    effects.SetEffect(new Laxative());
                    break;
                case Glowing glowing:
                    effects.SetEffect(glowing, false);
                    effects.SetEffect(new Disorienting());
                    break;
                case Schizophrenic schizophrenic:
                    effects.SetEffect(schizophrenic, false);
                    effects.SetEffect(new Balding());
                    break;
                case Sedating sedating:
                    effects.SetEffect(sedating, false);
                    effects.SetEffect(new Munchies());
                    break;
                case Spicy spicy:
                    effects.SetEffect(spicy, false);
                    effects.SetEffect(new Euphoric());
                    break;
                case TropicThunder tropicThunder:
                    effects.SetEffect(tropicThunder, false);
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
