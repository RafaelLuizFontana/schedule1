using System;
using Schedule1ConsoleApp.Model.Drug;
using Schedule1ConsoleApp.Model.Interface;

namespace Schedule1ConsoleApp.Model.Ingredient;

public class Banana : IIngredient
{
    public string Name()
    {
        return "Banana";
    }

    public IEffect BaseEffect()
    {
        return new Gingeritis();
    }

    public decimal Cost(){
        return 2.0m;
    }

    public GenericMix Mix(IBaseDrug drug){
        GenericMix genericMix;
        if (drug is GenericMix mix)
        {
            genericMix = mix;
        } else{
            genericMix = new(drug);
        }
        EffectList effects = genericMix.Effects();
        foreach (EffectListItem effect in effects.GetEffects()){
            switch(effect.Effect){
                case Calming calming:
                    effects.SetEffect(calming, false);
                    effects.SetEffect(new Sneaky());
                    break;
                case Cyclopean cyclopean:
                    if(!effects.HasEffect(new Energizing())){
                        effects.SetEffect(cyclopean, false);
                        effects.SetEffect(new ThoughtProvoking());
                    }
                    break;
                case Disorienting disorienting:
                    effects.SetEffect(disorienting, false);
                    effects.SetEffect(new Focused());
                    break;
                case Energizing energizing:
                    if(!effects.HasEffect(new Cyclopean())){
                        effects.SetEffect(energizing, false);
                    }else{
                        effects.SetEffect(new Cyclopean(), false);    
                    }
                    effects.SetEffect(new ThoughtProvoking());
                    break;
                case Focused focused:
                    effects.SetEffect(focused, false);
                    effects.SetEffect(new SeizureInducing());
                    break;
                case LongFaced longFaced:
                    effects.SetEffect(longFaced, false);
                    effects.SetEffect(new Refreshing());
                    break;
                case Paranoia paranoia:
                    effects.SetEffect(paranoia, false);
                    effects.SetEffect(new Jennerising());
                    break;
                case Smelly smelly:
                    effects.SetEffect(smelly, false);
                    effects.SetEffect(new AntiGravity());
                    break;
                case Toxic toxic:
                    effects.SetEffect(toxic, false);
                    effects.SetEffect(new Smelly());
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
