using Schedule1ConsoleApp.Model.Effect;
using Schedule1ConsoleApp.Model.Interface;

namespace Schedule1ConsoleApp.Model.Drug;

public class GenericMix: IBaseDrug
{
    private readonly IBaseDrug baseDrug;
    private readonly EffectList effects;
    private readonly List<IIngredient> ingredients;
    private readonly IDrugType drugType;

    public GenericMix(IBaseDrug baseDrug)
    {
        if(baseDrug is GenericMix genericMix){
            this.baseDrug = genericMix.BaseDrug();
            effects = genericMix.Effects().ToList();
            ingredients = [.. genericMix.Ingredients()];
            drugType = genericMix.Type();
        } else {
            this.baseDrug = baseDrug;
            effects = new EffectList(baseDrug.BaseEffect());
            ingredients = [];
            drugType = baseDrug.Type();
        }
    }

    public string Name()
    {
        return "Generic " + baseDrug.Type().Name() + " Mix";
    }

    public IDrugType Type()
    {
        return drugType;
    }

    public IEffect BaseEffect()
    {
        return baseDrug.BaseEffect();
    }

    public IBaseDrug BaseDrug()
    {
        return baseDrug;
    }

    public decimal BaseValue(){
        return baseDrug.BaseValue();
    }

    public decimal Value()
    {
        decimal  sum = 1;
        decimal cost = 0;
        foreach (var effectListItem in effects.GetEffects())
        {
            sum += effectListItem.Effect.Multiplier();
        }
        foreach (var ingredient in ingredients){
            cost += ingredient.Cost();
        }
        return sum * baseDrug.BaseValue() - cost;
    }

    public EffectList Effects()
    {
        return effects;
    }

    public List<IIngredient> Ingredients()
    {
        return ingredients;
    }

    public GenericMix AddIngredient(IIngredient ingredient)
    {
        if (effects.Count() == 0 && BaseEffect() is not None) effects.SetEffect(BaseEffect());
        ingredients.Add(ingredient);
        if(ingredient.BaseEffect() is not CalorieDense) effects.SetEffect(ingredient.BaseEffect());
        List<EffectListItem> effectList = effects.GetEffects();
        if (effectList.Count == 0) return this;
        ingredient.Mix(this);
        return this;
    }

    public override bool Equals(object? obj)
    {
        if (obj == null) return false;
        GenericMix other = (GenericMix)obj;
        return effects.Equals(other.effects);
    }

    public override int GetHashCode()
    {
        return 0;
    }

}
