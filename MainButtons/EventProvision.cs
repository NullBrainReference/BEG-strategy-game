using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventProvision : MonoBehaviour
{
    public void EventNewProvision()
    {
        TurnMain.Instance.GetCurrentPlayer().organization += 50 * (TurnMain.Instance.GetCurrentPlayer().organizationBase/100);
        if(TurnMain.Instance.GetCurrentPlayer().organization > TurnMain.Instance.GetCurrentPlayer().organizationBase)
        {
            TurnMain.Instance.GetCurrentPlayer().organization = TurnMain.Instance.GetCurrentPlayer().organizationBase;
            //Debug.Log(TurnMain.Instance.GetCurrentPlayer().organization+" / " + )
        }
        TurnMain.Instance.scrollManager.UnitsOrgUpdate();
        //TurnMain.Instance.playerList[TurnMain.Instance.turn].SavePlayer();
        TurnMain.Instance.Turner(true);
    }
}
