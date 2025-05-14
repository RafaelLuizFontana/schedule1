using Schedule1ConsoleApp.Model.Drug;

namespace Schedule1ConsoleApp.Model.Ingredient;

public class MegaBean : IIngredient
{
    public string Name()
    {
        return "Mega Bean";
    }

    public IEffect BaseEffect()
    {
        return new Foggy();
    }

    public decimal Cost(){
        return 7.0m;
    }

    public GenericMix Mix(GenericMix genericMix){
        EffectList effects = genericMix.Effects();
        foreach(EffectListItem effect in  effects.GetEffects()){
            switch(effect.Effect){
                case Athletic athletic:
                    effects.SetEffect(athletic, false);
                    effects.SetEffect(new Laxative());
                    break;
                case Calming calming:
                    effects.SetEffect(calming, false);
                    effects.SetEffect(new Glowing());
                    break;
                case Energizing energizing:
                    if(!effects.HasEffect(new ThoughtProvoking())){
                        effects.SetEffect(energizing, false);
                        effects.SetEffect(new Cyclopean());
                    }
                    break;
                case Focused focused:
                    effects.SetEffect(focused, false);
                    effects.SetEffect(new Disorienting());
                    break;
                case Jennerising jennerising:
                    effects.SetEffect(jennerising, false);
                    effects.SetEffect(new Paranoia());
                    break;
                case SeizureInducing seizureInducing:
                    effects.SetEffect(seizureInducing, false);
                    effects.SetEffect(new Focused());
                    break;
                case Shrinking shrinking:
                    effects.SetEffect(shrinking, false);
                    effects.SetEffect(new Electrifying());
                    break;
                case Slippery slippery:
                    effects.SetEffect(slippery, false);
                    effects.SetEffect(new Toxic());
                    break;
                case Sneaky sneaky:
                    effects.SetEffect(sneaky, false);
                    effects.SetEffect(new Calming());
                    break;
                case ThoughtProvoking thoughtProvoking:
                    effects.SetEffect(thoughtProvoking, false);
                    if(effects.HasEffect(new Energizing())){
                        effects.SetEffect(new Cyclopean());
                    }else{
                        effects.SetEffect(new Energizing());
                    }
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
