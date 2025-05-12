using Schedule1ConsoleApp.Model.Drug;
using Schedule1ConsoleApp.Model.Interface;

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

    public decimal Cost(){
        return 3.0m;
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
                    effects.SetEffect(new Slippery());
                    break;
                case Electrifying electrifying:
                    effects.SetEffect(electrifying, false);
                    effects.SetEffect(new Athletic());
                    break;
                case Energizing energizing:
                    if(!effects.HasEffect(new Munchies())){
                        effects.SetEffect(energizing, false);
                        effects.SetEffect(new Paranoia());
                    }else if(!effects.HasEffect(new Paranoia())){
                        effects.SetEffect(energizing, false);
                        effects.SetEffect(new Balding());
                    }
                    break;
                case Focused focused:
                    effects.SetEffect(focused, false);
                    effects.SetEffect(new Gingeritis());
                    break;
                case Foggy foggy:
                    effects.SetEffect(foggy, false);
                    effects.SetEffect(new Glowing());
                    break;
                case Glowing glowing:
                    effects.SetEffect(glowing, false);
                    effects.SetEffect(new Toxic());
                    break;
                case Munchies munchies:
                    effects.SetEffect(munchies, false);
                    effects.SetEffect(new AntiGravity());
                    break;
                case Paranoia paranoia:
                    effects.SetEffect(paranoia, false);
                    effects.SetEffect(new Balding());
                    break;
                case Spicy spicy:
                    effects.SetEffect(spicy, false);
                    effects.SetEffect(new BrightEyed());
                    break;
                case Toxic toxic:
                    effects.SetEffect(toxic, false);
                    effects.SetEffect(new TropicThunder());
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
