using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyRegButton : MonoBehaviour
{
    //public CellController cellController;

    public void OnClick()
    {
        TurnMain.Instance.GetCurrentPlayer().RegAction = RegionAction.Money;
        TurnMain.Instance.RegActionUIupdate();
        //TurnMain.Instance.GetCurrentPlayer().SavePlayer();
    }
}
