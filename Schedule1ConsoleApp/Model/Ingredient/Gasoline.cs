using Schedule1ConsoleApp.Model.Drug;

namespace Schedule1ConsoleApp.Model.Ingredient;

public class Gasoline : IIngredient
{
    public string Name()
    {
        return "Gasoline";
    }

    public IEffect BaseEffect()
    {
        return new Toxic();
    }

    public decimal Cost(){
        return 5.0m;
    }

    public GenericMix Mix(GenericMix genericMix){
        EffectList effects = genericMix.Effects();
        foreach(EffectListItem effect in  effects.GetEffects()){
            switch(effect.Effect){
                case Disorienting disorienting:
                    effects.SetEffect(disorienting, false);
                    effects.SetEffect(new Glowing());
                    break;
                case Electrifying electrifying:
                    effects.SetEffect(electrifying, false);
                    effects.SetEffect(new Disorienting());
                    break;
                case Energizing energizing:
                    effects.SetEffect(energizing, false);
                    effects.SetEffect(new Spicy());
                    break;
                case Euphoric euphoric:
                    if(!effects.HasEffect(new Energizing())){
                        effects.SetEffect(euphoric, false);
                        effects.SetEffect(new Energizing());
                    }
                    break;
                case Gingeritis gingeritis:
                    effects.SetEffect(gingeritis, false);
                    effects.SetEffect(new Smelly());
                    break;
                case Jennerising jennerising:
                    effects.SetEffect(jennerising, false);
                    effects.SetEffect(new Sneaky());
                    break;
                case Laxative laxative:
                    effects.SetEffect(laxative, false);
                    effects.SetEffect(new Foggy());
                    break;
                case Munchies munchies:
                    effects.SetEffect(munchies, false);
                    effects.SetEffect(new Sedating());
                    break;
                case Paranoia paranoia:
                    effects.SetEffect(paranoia, false);
                    effects.SetEffect(new Calming());
                    break;
                case Shrinking shrinking:
                    effects.SetEffect(shrinking, false);
                    effects.SetEffect(new Focused());
                    break;
                case Sneaky sneaky:
                    effects.SetEffect(sneaky, false);
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
