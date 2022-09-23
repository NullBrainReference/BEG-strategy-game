using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitHeroKing : UnitBase
{
    public UnitHeroKing()
    {
        name = "King";
        unitType = UnitType.HeroKing;
        speed = 1;
        healthBase = 100;
        staminaBase = 80;
        stamina = 80;
        healthReg = 5;
        damageBase = 30;
        resistMagical = 0;
        resistPhisical = 0.45f;
        rangedAttack = 1;
        aсtionType = ActionType.Phisical;
    }

    public UnitHeroKing(UnitBase unitBase) : base(unitBase)
    {

    }

    public override void AbilityApply(Player other)
    {
        //base.AbilityApply(other);
        //Debug.Log("дописать абилку");
        if (this.parent.organization < this.parent.organizationBase) return;
        if(this.parent.units.Count < this.parent.unitLimit)
        {
            this.parent.Organization -= 50;
            UnitMilitary unit = new UnitMilitary();
            unit.parent = this.parent;
            this.parent.units.Add(unit);
            try
            {
                BattleManager.Instance.scrollManager.AddUnitCards(unit, unit.GetImage());
                this.parent.HealthOrgUpdate();
            }
            catch
            {
                TurnMain.Instance.scrollManager.AddUnitCards(unit, unit.GetImage());
                this.parent.HealthOrgUpdate();
            }
            //this.parent.SavePlayer();
        }
    }
    public override Sprite GetImage()
    {
        var sprite = Resources.Load<Sprite>("King");
        return sprite;
    }
}
