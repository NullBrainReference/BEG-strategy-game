using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitPork : UnitBase
{
    public UnitPork()
    {
        unitType = UnitType.Pork;
        speed = 1;
        healthBase = 50;
        staminaBase = 50;
        stamina = 50;
        healthReg = 2;
        damageBase = 20;
        resistMagical = 0;
        resistPhisical = 0.2f;
        rangedAttack = 1;
        aсtionType = ActionType.Phisical;
    }

    public UnitPork(UnitBase unitBase) : base(unitBase)
    {

    }

    public override Sprite GetImage()
    {
        var sprite = Resources.Load<Sprite>("Pork");
        //Image image = Resources.Load("Default") as Image;
        //Debug.Log("UMilitary.GI");
        return sprite;
    }
}
