using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : ModificatorBase
{

    public Bomb()
    {
        effecType = EffecType.Bomb;
        damage = 35;
    }

    //public Bomb(ModificatorBase modBase) : base(modBase)
    //{
    //
    //}

    public override Sprite GetImage()
    {
        var sprite = Resources.Load<Sprite>("Bomb");
        //Image image = Resources.Load("Default") as Image;
        //Debug.Log("UMilitary.GI");
        return sprite;
    }


}