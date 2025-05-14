using Schedule1ConsoleApp.Model.Drug;

namespace Schedule1ConsoleApp.Model.Ingredient;

public class Viagor : IIngredient
{
    public string Name()
    {
        return "Viagor";
    }

    public IEffect BaseEffect()
    {
        return new TropicThunder();
    }

    public decimal Cost(){
        return 4.0m;
    }

    public GenericMix Mix(GenericMix genericMix){
        EffectList effects = genericMix.Effects();
        foreach(EffectListItem effect in  effects.GetEffects()){
            switch(effect.Effect){
                case Athletic athletic:
                    effects.SetEffect(athletic, false);
                    effects.SetEffect(new Sneaky());
                    break;
                case Disorienting disorienting:
                    effects.SetEffect(disorienting, false);
                    effects.SetEffect(new Toxic());
                    break;
                case Euphoric euphoric:
                    effects.SetEffect(euphoric, false);
                    effects.SetEffect(new BrightEyed());
                    break;
                case Laxative laxative:
                    effects.SetEffect(laxative, false);
                    effects.SetEffect(new Calming());
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
