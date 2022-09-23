using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitArchers : UnitBase
{
    public UnitArchers()
    {
        name = "Archer";
        unitType = UnitType.Archers;
        speed = 1;
        healthBase = 30;
        staminaBase = 50;
        stamina = 50;
        healthReg = 1;
        damageBase = 20;
        resistMagical = 0;
        resistPhisical = 0.1f;
        rangedAttack = 2;
        aсtionType = ActionType.Phisical;

    }

    public UnitArchers(UnitBase unitBase) : base(unitBase)
    {

    }

    public override Sprite GetImage()
    {
        var sprite = Resources.Load<Sprite>("Archers");
        //Image image = Resources.Load("Default") as Image;
        //Debug.Log("UMilitary.GI");
        return sprite;
    }
}
