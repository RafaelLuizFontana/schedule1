using Schedule1ConsoleApp.Model.Drug;
using Schedule1ConsoleApp.Model.Interface;

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
                case Athletic athletic:
                    effects.SetEffect(athletic, false);
                    effects.SetEffect(new Munchies());
                    break;
                case Calming calming:
                    effects.SetEffect(calming, false);
                    effects.SetEffect(new BrightEyed());
                    break;
                case Cyclopean cyclopean:
                    effects.SetEffect(cyclopean, false);
                    effects.SetEffect(new Foggy());
                    break;
                case Electrifying electrifying:
                    effects.SetEffect(electrifying, false);
                    effects.SetEffect(new Refreshing());
                    break;
                case Euphoric euphoric:
                    effects.SetEffect(euphoric, false);
                    effects.SetEffect(new Toxic());
                    break;
                case Focused focused:
                    effects.SetEffect(focused, false);
                    effects.SetEffect(new Calming());
                    break;
                case Laxative laxative:
                    effects.SetEffect(laxative, false);
                    effects.SetEffect(new Euphoric());
                    break;
                case Munchies munchies:
                    effects.SetEffect(munchies, false);
                    effects.SetEffect(new Slippery());
                    break;
                case Shrinking shrinking:
                    effects.SetEffect(shrinking, false);
                    effects.SetEffect(new Paranoia());
                    break;
                case ThoughtProvoking thoughtProvoking:
                    effects.SetEffect(thoughtProvoking, false);
                    effects.SetEffect(new Gingeritis());
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
