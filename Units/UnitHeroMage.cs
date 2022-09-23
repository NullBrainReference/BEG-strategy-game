using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitHeroMage : UnitBase
{


    public UnitHeroMage()
    {
        name = "Mage";
        unitType = UnitType.HeroMage;
        speed = 1;
        healthBase = 100;
        staminaBase = 50;
        stamina = 50;
        healthReg = 5;
        damageBase = 40;
        resistMagical = 0.8f;
        resistPhisical = 0.1f;
        rangedAttack = 2; 
        aсtionType = ActionType.Magic;
    }

    public UnitHeroMage(UnitBase unitBase) : base(unitBase)
    {

    }

    public override void AbilityApply(Player other)
    {
        if (other != this.parent)
        {
            float ultimate = damageBase * (parent.Mana / parent.manaBase);
            foreach (UnitBase unit in other.units)
                unit.TakeAction(ActionType.Magic, ultimate);
            this.parent.Mana = 0;
        }

        //GameVariables gameVariables = GameVariables.Get();
        //Player player1 = Player.GetPlayer(gameVariables.curplayer);
        //Player player2 = Player.GetPlayer(gameVariables.enemyPlayer);
        //if (player1 != this.parent) other = player1;
        //if (player2 != this.parent) other = player2;
        //
        //if (this.parent.Mana >= 150 && (this.parent.Mana + this.parent.manaBase) >= 2 * (this.parent.manaBase / 3))
        //{
        //    foreach (UnitBase unit in other.units)
        //        unit.realHealth -= this.Damage * (1-unit.resistMagical);
        //}
        this.parent.SavePlayer();
        other.SavePlayer();
    }
    public override Sprite GetImage()
    {
        Debug.Log("mage img");
        var sprite = Resources.Load<Sprite>("Mage");
        return sprite;
    }
}
