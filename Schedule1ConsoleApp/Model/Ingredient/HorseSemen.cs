using Schedule1ConsoleApp.Model.Drug;

namespace Schedule1ConsoleApp.Model.Ingredient;

public class HorseSemen : IIngredient
{
    public string Name()
    {
        return "Horse Semen";
    }

    public IEffect BaseEffect()
    {
        return new LongFaced();
    }

    public decimal Cost(){
        return 9.0m;
    }

    public GenericMix Mix(GenericMix genericMix){
        EffectList effects = genericMix.Effects();
        foreach(EffectListItem effect in  effects.GetEffects()){
            switch(effect.Effect){
                case AntiGravity antiGravity:
                    effects.SetEffect(antiGravity, false);
                    effects.SetEffect(new Calming());
                    break;
                case Gingeritis gingeritis:
                    effects.SetEffect(gingeritis, false);
                    effects.SetEffect(new Refreshing());
                    break;
                case ThoughtProvoking thoughtProvoking:
                    effects.SetEffect(thoughtProvoking, false);
                    effects.SetEffect(new Electrifying());
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
