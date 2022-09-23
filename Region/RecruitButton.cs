using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecruitButton : MonoBehaviour
{
    public Text recruitText;
    void Start()
    {
        recruitText.text = "Recruit " + this.transform.GetComponentInParent<RegionConrtoller>().regionBase.unitType.ToString();
    }

    public void OnClick()
    {
        RegionConrtoller regionConrtoller = GetComponentInParent<RegionConrtoller>();
        if (TurnMain.Instance.GetCurrentPlayer().UnitLimitCheck() && moneyCheck()) 
        {
            switch (regionConrtoller.regionBase.unitType)
            {
                case UnitType.Military:
                    UnitBase military = new UnitMilitary();
                    military.parent = TurnMain.Instance.GetCurrentPlayer();
                    military.parent.charecterType = TurnMain.Instance.GetCurrentPlayer().charecterType;

                    TurnMain.Instance.GetCurrentPlayer().units.Add(military);
                    TurnMain.Instance.scrollManager.AddUnitCards(military, military.GetImage());
                    //TurnMain.Instance.GetCurrentPlayer().SavePlayer();
                    break;
                case UnitType.Archers:
                    UnitBase archers = new UnitArchers();
                    archers.parent = TurnMain.Instance.GetCurrentPlayer();
                    archers.parent.charecterType = TurnMain.Instance.GetCurrentPlayer().charecterType;

                    TurnMain.Instance.GetCurrentPlayer().units.Add(archers);
                    TurnMain.Instance.scrollManager.AddUnitCards(archers, archers.GetImage());
                    //TurnMain.Instance.GetCurrentPlayer().SavePlayer();
                    break;
                case UnitType.Mount:
                    UnitBase mount = new UnitMount();
                    mount.parent = TurnMain.Instance.GetCurrentPlayer();
                    mount.parent.charecterType = TurnMain.Instance.GetCurrentPlayer().charecterType;

                    TurnMain.Instance.GetCurrentPlayer().units.Add(mount);
                    TurnMain.Instance.scrollManager.AddUnitCards(mount, mount.GetImage());
                    //TurnMain.Instance.GetCurrentPlayer().SavePlayer();
                    break;
            }

            TurnMain.Instance.GetCurrentPlayer().money -= 100;
            TurnMain.Instance.UI_Update();
        }
    }
    private bool moneyCheck()
    {
        bool check = false;
        if (TurnMain.Instance.GetCurrentPlayer().money >= 100) check = true;
        return check;
    }
}
