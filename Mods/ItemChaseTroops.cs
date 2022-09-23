using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemChaseTroops : ItemBase
{
    public ItemChaseTroops()
    {
        base.itemType = ItemType.Chaser;
        base.name = "ChaseTroops";
        base.damage = 0;
        base.shoPrice = 100;
        manaCost = 0;
    }
    public override void MakeAction(UnitBase unitBase)
    {
        unitBase.parent.escapeAbillity = false;
    }
    public override Sprite GetImage()
    {
        var sprite = Resources.Load<Sprite>("ChaseTroops");

        return sprite;
    }
}
