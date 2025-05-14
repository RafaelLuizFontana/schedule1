using Schedule1ConsoleApp.Model.Drug;

namespace Schedule1ConsoleApp.Model.Ingredient;

public class Battery : IIngredient
{
    public string Name()
    {
        return "Battery";
    }

    public IEffect BaseEffect()
    {
        return new BrightEyed();
    }

    public decimal Cost(){
        return 8.0m;
    }

    public GenericMix Mix(GenericMix genericMix){
        EffectList effects = genericMix.Effects();
        foreach(EffectListItem effect in effects.GetEffects()){
            switch(effect.Effect){
                case Cyclopean cyclopean:
                    effects.SetEffect(cyclopean, false);
                    effects.SetEffect(new Glowing());
                    break;
                case Electrifying electrifying:
                    if(!effects.HasEffect(new Zombifying())){
                        effects.SetEffect(electrifying, false);
                        effects.SetEffect(new Euphoric());
                    }
                    break;
                case Euphoric euphoric:
                    if(!effects.HasEffect(new Electrifying())){
                        effects.SetEffect(euphoric, false);
                        effects.SetEffect(new Zombifying());
                    }
                    break;
                case Laxative laxative:
                    effects.SetEffect(laxative, false);
                    effects.SetEffect(new CalorieDense());
                    break;
                case Munchies munchies:
                    effects.SetEffect(munchies, false);
                    effects.SetEffect(new TropicThunder());
                    break;
                case Shrinking shrinking:
                    effects.SetEffect(shrinking, false);
                    effects.SetEffect(new Munchies());
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
