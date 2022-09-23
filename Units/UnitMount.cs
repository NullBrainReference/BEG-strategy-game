using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMount : UnitBase
{
    public UnitMount()
    {
        name = "Knight";
        unitType = UnitType.Mount;
        speed = 3;
        healthBase = 40;
        staminaBase = 50;
        stamina = 50;
        healthReg = 2;
        damageBase = 15;
        resistMagical = 0;
        resistPhisical = 0.7f;
        rangedAttack = 1;
        aсtionType = ActionType.Phisical;
    }

    public UnitMount(UnitBase unitBase) : base(unitBase)
    {

    }

    public override Sprite GetImage()
    {
        var sprite = Resources.Load<Sprite>("Mount");
        //Image image = Resources.Load("Default") as Image;
        //Debug.Log("UMilitary.GI");
        return sprite;
    }
}
