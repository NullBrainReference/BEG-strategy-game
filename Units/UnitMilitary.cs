using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitMilitary : UnitBase
{

    public UnitMilitary()
    {
        name = "Militia";
        unitType = UnitType.Military;
        speed = 1;
        healthBase = 65;
        staminaBase = 50;
        stamina = 50;
        healthReg = 2;
        damageBase = 25;
        resistMagical = 0.1f;
        resistPhisical = 0.3f;
        rangedAttack = 1;
        aсtionType = ActionType.Phisical;
    }

    public UnitMilitary(UnitBase unitBase) :base(unitBase)
    {

    }

    public override Sprite GetImage()
    {
        var sprite = Resources.Load<Sprite>("Military");
        //Image image = Resources.Load("Default") as Image;
        //Debug.Log("UMilitary.GI");
        return sprite;
    }

}
