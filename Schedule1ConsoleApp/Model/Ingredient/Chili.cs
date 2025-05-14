using Schedule1ConsoleApp.Model.Drug;

namespace Schedule1ConsoleApp.Model.Ingredient;

public class Chili : IIngredient
{
    public string Name()
    {
        return "Chili";
    }

    public IEffect BaseEffect()
    {
        return new Spicy();
    }

    public decimal Cost(){
        return 7.0m;
    }

    public GenericMix Mix(GenericMix genericMix){
        EffectList effects = genericMix.Effects();
        foreach(EffectListItem effect in effects.GetEffects()){
            switch(effect.Effect){
                case AntiGravity antiGravity:
                    effects.SetEffect(antiGravity, false);
                    effects.SetEffect(new TropicThunder());
                    break;
                case Athletic athletic:
                    effects.SetEffect(athletic, false);
                    effects.SetEffect(new Euphoric());
                    break;
                case Laxative laxative:
                    effects.SetEffect(laxative, false);
                    effects.SetEffect(new LongFaced());
                    break;
                case Munchies munchies:
                    effects.SetEffect(munchies, false);
                    effects.SetEffect(new Toxic());
                    break;
                case Shrinking shrinking:
                    effects.SetEffect(shrinking, false);
                    effects.SetEffect(new Refreshing());
                    break;
                case Sneaky sneaky:
                    effects.SetEffect(sneaky, false);
                    effects.SetEffect(new BrightEyed());
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
