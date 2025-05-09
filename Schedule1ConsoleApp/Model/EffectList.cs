using System;
using Schedule1ConsoleApp.Model.Effect;

namespace Schedule1ConsoleApp.Model;

public class EffectList
{
    private readonly List<EffectListItem> effectList;

    private int count;

    private long id;

    public EffectList() { 
        effectList = [];
        count = 0;
        InitList();
        GenerateID();
    }

    public EffectList(IEffect effect) : this(){
        if (effect is not None) SetEffect(effect);
    }

    private EffectList AddEffectItem(IEffect effect, bool isPresent = false)
    {
        EffectListItem effectListItem = new(effect, isPresent);
        effectList.Add(effectListItem);
        GenerateID();
        return this;
    }

    public List<EffectListItem> GetEffects(){
        List<EffectListItem> list = [];
        foreach (EffectListItem item in effectList){
            if (item.IsPresent) list.Add(item);
        }
        return list;
    }

    private void InitList(){
        AddEffectItem(new AntiGravity())
        .AddEffectItem(new Athletic())
        .AddEffectItem(new Balding())
        .AddEffectItem(new BrightEyed())
        .AddEffectItem(new Calming())
        .AddEffectItem(new CalorieDense())
        .AddEffectItem(new Cyclopean())
        .AddEffectItem(new Disorienting())
        .AddEffectItem(new Electrifying())
        .AddEffectItem(new Energizing())
        .AddEffectItem(new Euphoric())
        .AddEffectItem(new Explosive())
        .AddEffectItem(new Focused())
        .AddEffectItem(new Foggy())
        .AddEffectItem(new Gingeritis())
        .AddEffectItem(new Glowing())
        .AddEffectItem(new Jennerising())
        .AddEffectItem(new Laxative())
        .AddEffectItem(new LongFaced())
        .AddEffectItem(new Munchies())
        .AddEffectItem(new Paranoia())
        .AddEffectItem(new Refreshing())
        .AddEffectItem(new Schizophrenic())
        .AddEffectItem(new Sedating())
        .AddEffectItem(new SeizureInducing())
        .AddEffectItem(new Shrinking())
        .AddEffectItem(new Slippery())
        .AddEffectItem(new Smelly())
        .AddEffectItem(new Sneaky())
        .AddEffectItem(new Spicy())
        .AddEffectItem(new ThoughtProvoking())
        .AddEffectItem(new Toxic())
        .AddEffectItem(new TropicThunder())
        .AddEffectItem(new Zombifying());
    }

    public int Count(){
        return count;
    }

    public int Size(){
        return effectList.Count;
    }

    public void SetEffect(IEffect effect, bool isPresent = true)
    {
        EffectListItem? listItem = effectList.Find(x => x.Effect.Name() == effect.Name()) ?? throw new ArgumentException($"Effect {effect.Name()} not found in the list.");
        if (listItem.IsPresent == isPresent) return;
        listItem.IsPresent = isPresent;
        if (isPresent)
        {
            count++;
        }
        else
        {
            count--;
        }
        GenerateID();
    }

    public bool HasEffect(IEffect effect){
        EffectListItem? listItem = effectList.Find(x => x.Effect.Name() == effect.Name()) ?? throw new ArgumentException($"Effect {effect.Name()} not found in the list.");
        return listItem.IsPresent;
    }

    public EffectListItem GetEffectListItemByIndex(int index){
        if (index < 0 || index >= effectList.Count) throw new ArgumentOutOfRangeException($"Index {index} is out of range.");
        return effectList[index];
    }

    public EffectList ToList(){
        EffectList list = new();
        foreach (EffectListItem item in effectList){
            list.SetEffect(item.Effect, item.IsPresent);
        }
        return list;
    }

    public void GenerateID(){
        long id = 0;
        for(int i = 0; i < effectList.Count; i++){
            if(effectList[i].IsPresent){
                id |= 1L << i;
            }
        }
        this.id = id;
    }

    public long GetID(){
        return id;
    }

    public override bool Equals(object? obj)
    {
        if (obj == null) return false;
        EffectList other = (EffectList)obj;
        return GetID() == other.GetID();
    }

    public override int GetHashCode()
    {
        return 0;
    }
}
