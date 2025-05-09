using Schedule1ConsoleApp.Model.Effect;
using Schedule1ConsoleApp.Model.Ingredient;
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
        foreach (var effectListItem in effects.GetEffects())
        {
            sum += effectListItem.Effect.Multiplier();
        }
        return sum * baseDrug.BaseValue();
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
        foreach (var effectListItem in effectList){
            switch(ingredient){
                case Cuke:
                    switch(effectListItem.Effect){
                        case Euphoric euphoric:
                            effects.SetEffect(euphoric, false);
                            effects.SetEffect(new Laxative());
                            break;
                        case Foggy foggy:
                            effects.SetEffect(foggy, false);
                            effects.SetEffect(new Cyclopean());
                            break;
                        case Gingeritis gingeritis:
                            effects.SetEffect(gingeritis, false);
                            effects.SetEffect(new ThoughtProvoking());
                            break;
                        case Munchies munchies:
                            effects.SetEffect(munchies, false);
                            effects.SetEffect(new Athletic());
                            break;
                        case Slippery slippery:
                            effects.SetEffect(slippery, false);
                            if(effects.HasEffect(new Munchies())){
                                effects.SetEffect(new Athletic());
                            }else{
                                effects.SetEffect(new Munchies());
                            }
                            break;
                        case Sneaky sneaky:
                            effects.SetEffect(sneaky, false);
                            effects.SetEffect(new Paranoia());
                            break;
                        case Toxic toxic:
                            effects.SetEffect(toxic, false);
                            effects.SetEffect(new Euphoric());
                            break;
                        default:
                            break;
                    }
                    break;
                case Banana:
                    switch(effectListItem.Effect){
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
                    break;
                case Paracetamol:
                    switch(effectListItem.Effect){
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
                    break;
                case Donut:
                    switch(effectListItem.Effect){
                        case AntiGravity antiGravity:
                            effects.SetEffect(antiGravity, false);
                            effects.SetEffect(new CalorieDense());
                            effects.SetEffect(new Slippery());
                            break;
                        case Balding balding:
                            effects.SetEffect(balding, false);
                            effects.SetEffect(new CalorieDense());
                            effects.SetEffect(new Sneaky());
                            break;
                        case CalorieDense calorieDense:
                            if(!effects.HasEffect(new Explosive())){
                                effects.SetEffect(calorieDense, false);
                                effects.SetEffect(new Explosive());
                            }
                            break;
                        case Focused focused:
                            effects.SetEffect(focused, false);
                            effects.SetEffect(new CalorieDense());
                            effects.SetEffect(new Euphoric());
                            break;
                        case Jennerising jennerising:
                            effects.SetEffect(jennerising, false);
                            effects.SetEffect(new CalorieDense());
                            effects.SetEffect(new Gingeritis());
                            break;
                        case Munchies munchies:
                            effects.SetEffect(munchies, false);
                            effects.SetEffect(new CalorieDense());
                            effects.SetEffect(new Calming());
                            break;
                        case Shrinking shrinking:
                            effects.SetEffect(shrinking, false);
                            effects.SetEffect(new CalorieDense());
                            effects.SetEffect(new Energizing());
                            break;
                        default:
                            effects.SetEffect(new CalorieDense());
                            break;
                    }
                    break;
                case Viagor:
                    switch(effectListItem.Effect){
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
                    break;
                case MouthWash:
                    switch(effectListItem.Effect){
                        case Calming calming:
                            effects.SetEffect(calming, false);
                            effects.SetEffect(new AntiGravity());
                            break;
                        case CalorieDense calorieDense:
                            effects.SetEffect(calorieDense, false);
                            effects.SetEffect(new Sneaky());
                            break;
                        case Explosive explosive:
                            effects.SetEffect(explosive, false);
                            effects.SetEffect(new Sedating());
                            break;
                        case Focused focused:
                            effects.SetEffect(focused, false);
                            effects.SetEffect(new Jennerising());
                            break;
                        default:
                            break;
                    }
                    break;
                case FluMedicine:
                    switch(effectListItem.Effect){
                        case Athletic athletic:
                            effects.SetEffect(athletic, false);
                            effects.SetEffect(new Munchies());
                            break;
                        case Calming calming:
                            effects.SetEffect(calming, false);
                            effects.SetEffect(new BrightEyed());
                            break;
                        case Cyclopean cyclopean:
                            effects.SetEffect(cyclopean, false);
                            effects.SetEffect(new Foggy());
                            break;
                        case Electrifying electrifying:
                            effects.SetEffect(electrifying, false);
                            effects.SetEffect(new Refreshing());
                            break;
                        case Euphoric euphoric:
                            effects.SetEffect(euphoric, false);
                            effects.SetEffect(new Toxic());
                            break;
                        case Focused focused:
                            effects.SetEffect(focused, false);
                            effects.SetEffect(new Calming());
                            break;
                        case Laxative laxative:
                            effects.SetEffect(laxative, false);
                            effects.SetEffect(new Euphoric());
                            break;
                        case Munchies munchies:
                            effects.SetEffect(munchies, false);
                            effects.SetEffect(new Slippery());
                            break;
                        case Shrinking shrinking:
                            effects.SetEffect(shrinking, false);
                            effects.SetEffect(new Paranoia());
                            break;
                        case ThoughtProvoking thoughtProvoking:
                            effects.SetEffect(thoughtProvoking, false);
                            effects.SetEffect(new Gingeritis());
                            break;
                        default:
                            break;
                    }
                    break;
                case Gasoline:
                    switch(effectListItem.Effect){
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
                    break;
                case EnergyDrink:
                    switch(effectListItem.Effect){
                        case Disorienting disorienting:
                            effects.SetEffect(disorienting, false);
                            effects.SetEffect(new Electrifying());
                            break;
                        case Euphoric euphoric:
                            effects.SetEffect(euphoric, false);
                            effects.SetEffect(new Energizing());
                            break;
                        case Focused focused:
                            effects.SetEffect(focused, false);
                            effects.SetEffect(new Shrinking());
                            break;
                        case Foggy foggy:
                            effects.SetEffect(foggy, false);
                            effects.SetEffect(new Laxative());
                            break;
                        case Glowing glowing:
                            effects.SetEffect(glowing, false);
                            effects.SetEffect(new Disorienting());
                            break;
                        case Schizophrenic schizophrenic:
                            effects.SetEffect(schizophrenic, false);
                            effects.SetEffect(new Balding());
                            break;
                        case Sedating sedating:
                            effects.SetEffect(sedating, false);
                            effects.SetEffect(new Munchies());
                            break;
                        case Spicy spicy:
                            effects.SetEffect(spicy, false);
                            effects.SetEffect(new Euphoric());
                            break;
                        case TropicThunder tropicThunder:
                            effects.SetEffect(tropicThunder, false);
                            effects.SetEffect(new Sneaky());
                            break;
                        default:
                            break;
                    }
                    break;
                case MotorOil:
                    switch(effectListItem.Effect){
                        case Energizing energizing:
                            effects.SetEffect(energizing, false);
                            effects.SetEffect(new Munchies());
                            break;
                        case Euphoric euphoric:
                            effects.SetEffect(euphoric, false);
                            effects.SetEffect(new Sedating());
                            break;
                        case Foggy foggy:
                            effects.SetEffect(foggy, false);
                            effects.SetEffect(new Toxic());
                            break;
                        case Munchies munchies:
                            if(!effects.HasEffect(new Energizing())){
                                effects.SetEffect(munchies, false);
                                effects.SetEffect(new Schizophrenic());
                            }
                            break;
                        case Paranoia paranoia:
                            effects.SetEffect(paranoia, false);
                            effects.SetEffect(new AntiGravity());
                            break;
                        default:
                            break;
                    }
                    break;
                case MegaBean:
                    switch(effectListItem.Effect){
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
                    break;
                case Chili:
                    switch(effectListItem.Effect){
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
                    break;
                case Battery:
                    switch(effectListItem.Effect){
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
                    break;
                case Iodine:
                    switch(effectListItem.Effect){
                        case Calming calming:
                            effects.SetEffect(calming, false);
                            effects.SetEffect(new Balding());
                            break;
                        case CalorieDense calorieDense:
                            effects.SetEffect(calorieDense, false);
                            effects.SetEffect(new Gingeritis());
                            break;
                        case Euphoric euphoric:
                            effects.SetEffect(euphoric, false);
                            effects.SetEffect(new SeizureInducing());
                            break;
                        case Foggy foggy:
                            effects.SetEffect(foggy, false);
                            effects.SetEffect(new Paranoia());
                            break;
                        case Refreshing refreshing:
                            effects.SetEffect(refreshing, false);
                            effects.SetEffect(new ThoughtProvoking());
                            break;
                        case Toxic toxic:
                            effects.SetEffect(toxic, false);
                            effects.SetEffect(new Sneaky());
                            break;
                        default:
                            break;
                    }
                    break;
                case Addy:
                    switch(effectListItem.Effect){
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
                    break;
                case HorseSemen:
                    switch(effectListItem.Effect){
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
                    break;
                default:
                    break;
            }
        }
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
