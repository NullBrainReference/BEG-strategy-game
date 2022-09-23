using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dagon : ItemBase
{

    public Dagon()
    {
        base.itemType = ItemType.Dagon;
        base.name = "Dagon";
        base.damage = 50;
        base.shoPrice = 100;
        manaCost = 150;
    }
    public override void MakeAction(UnitBase unitBase)
    {
        unitBase.realHealth -= damage*(1-unitBase.resistMagical);
    }
    public override Sprite GetImage()
    {
        var sprite = Resources.Load<Sprite>("Dagon");

        return sprite;
    }
}