using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UnitHeroAssasin : UnitBase
{


    public UnitHeroAssasin()
    {
        name = "Assasin";
        unitType = UnitType.HeroAssasin;
        speed = 2;
        healthBase = 70;
        staminaBase = 150;
        stamina = 150;
        healthReg = 5;
        damageBase = 30;
        resistMagical = 0.7f;
        resistPhisical = 0.3f;
        rangedAttack = 1;
        aсtionType = ActionType.Phisical;
    }

    public UnitHeroAssasin(UnitBase unitBase) : base(unitBase)
    {

    }

    public override void AbilityApply(Player other)
    {
        if (parent.Mana == parent.manaBase)
        {
            parent.Mana = 0;
            this.parent.SavePlayer();
            SceneManager.LoadScene("MainScene3", LoadSceneMode.Single);
        }
    }
    public override Sprite GetImage()
    {

        var sprite = Resources.Load<Sprite>("Assasin");
        return sprite;
    }
}
