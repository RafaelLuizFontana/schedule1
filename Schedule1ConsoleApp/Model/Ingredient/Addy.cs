using Schedule1ConsoleApp.Model.Drug;

namespace Schedule1ConsoleApp.Model.Ingredient;

public class Addy : IIngredient
{
    public string Name()
    {
        return "Addy";
    }

    public IEffect BaseEffect()
    {
        return new ThoughtProvoking();
    }

    public decimal Cost()
    {
        return 9.0m;
    }

    public GenericMix Mix(GenericMix genericMix){
        EffectList effects = genericMix.Effects();
        foreach(EffectListItem effect in effects.GetEffects()){
            switch(effect.Effect){
                case Explosive explosive:
                    effects.SetEffect(explosive, false);
                    effects.SetEffect(new Euphoric());
                    break;
                case Foggy foggy:
                    effects.SetEffect(foggy, false);
                    effects.SetEffect(new Energizing());
                    break;
                case Glowing glowing:
                    effects.SetEffect(glowing, false);
                    effects.SetEffect(new Refreshing());
                    break;
                case LongFaced longFaced:
                    effects.SetEffect(longFaced, false);
                    effects.SetEffect(new Electrifying());
                    break;
                case Sedating sedating:
                    effects.SetEffect(sedating, false);
                    effects.SetEffect(new Gingeritis());
                    break;
                default:
                    break;
            }
        }
        return genericMix;
    }
    
    public override bool Equals(object? obj) {
        if (obj == null || GetType() != obj.GetType()) return false;
        var other = (IIngredient)obj;
        return Name() == other.Name() && BaseEffect().GetHashCode() == other.BaseEffect().GetHashCode();
    }

    public override int GetHashCode() {
        return 0;
    }
}
