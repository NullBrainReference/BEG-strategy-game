using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaBooster: ItemBase
{
    public ManaBooster()
    {
        base.itemType = ItemType.ManaStone;
        base.name = "Mana Stone";
        base.shoPrice = 100;
    }
    public override Sprite GetImage()
    {
        var sprite = Resources.Load<Sprite>("ManaStone");

        return sprite;
    }
}
