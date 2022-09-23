using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType { ManaStone, Dagon, Chaser}
[System.Serializable]
public class ItemBase
{
    public ItemType itemType;
    public string name;
    public float damage;
    public float manaCost;
    public int shoPrice;
    public bool isUsable;

    public ModificatorBase modificator;
    public ModController controller;
    public Player parent;

    public ItemBase()
    {

    }
    public virtual void MakeAction(UnitBase unitBase)
    {

    }
    public ItemBase Copy()
    {
        ItemBase item = new ItemBase();
        item.itemType = itemType;
        item.name = name;
        item.shoPrice = shoPrice;
        item.manaCost = manaCost;
        item.isUsable = isUsable;
        item.damage = damage;
        item.parent = parent;
        return item;
    }
    public virtual Sprite GetImage()
    {
        var sprite = Resources.Load<Sprite>("Default");

        return sprite;
    }
    public ItemBase TypeCorrector()
    { 
        if (itemType == ItemType.Dagon) return new Dagon();
        if (itemType == ItemType.ManaStone) return new ManaBooster();
        if (itemType == ItemType.Chaser) return new ItemChaseTroops();

        Debug.LogError("добавить тип");
        return null;

    }
}
