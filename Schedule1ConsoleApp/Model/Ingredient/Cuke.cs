using Schedule1ConsoleApp.Model.Drug;
using Schedule1ConsoleApp.Model.Interface;

namespace Schedule1ConsoleApp.Model.Ingredient;

public class Cuke : IIngredient
{
    public string Name()
    {
        return "Cuke";
    }

    public IEffect BaseEffect()
    {
        return new Energizing();
    }

    public decimal Cost(){
        return 2.0m;
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
                case Euphoric euphoric:
                    effects.SetEffect(euphoric, false);
                    effects.SetEffect(new Laxative());
                    break;
                case Foggy foggy:
                    effects.SetEffect(foggy, false);
                    effects.SetEffect(new Cyclopean());
                    break;
                case Gingeritis gingeritis:
                    effects.SetEffect(gingeritis, false);
                    effects.SetEffect(new ThoughtProvoking());
                    break;
                case Munchies munchies:
                    effects.SetEffect(munchies, false);
                    effects.SetEffect(new Athletic());
                    break;
                case Slippery slippery:
                    effects.SetEffect(slippery, false);
                    if(effects.HasEffect(new Munchies())){
                        effects.SetEffect(new Athletic());
                    }else{
                        effects.SetEffect(new Munchies());
                    }
                    break;
                case Sneaky sneaky:
                    effects.SetEffect(sneaky, false);
                    effects.SetEffect(new Paranoia());
                    break;
                case Toxic toxic:
                    effects.SetEffect(toxic, false);
                    effects.SetEffect(new Euphoric());
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
