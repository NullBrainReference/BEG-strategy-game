using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UnitHeroSniper : UnitBase
{
    public UnitHeroSniper()
    {
        name = "Sniper";
        unitType = UnitType.HeroSniper;
        speed = 1;
        healthBase = 55;
        staminaBase = 50;
        stamina = 50;
        healthReg = 5;
        damageBase = 40;
        resistMagical = 0.6f;
        resistPhisical = 0.2f;
        rangedAttack = 3;
        añtionType = ActionType.Phisical;
    }

    public UnitHeroSniper(UnitBase unitBase) : base(unitBase)
    {

    }

    public override void AbilityApply(Player other)
    {

    }
    public override Sprite GetImage()
    {

        var sprite = Resources.Load<Sprite>("Sniper");
        return sprite;
    }
}
