using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrganizationManager : MonoBehaviour
{
    public Text text;
    public Slider organizationBar;


    public void OrgUppdate()
    {
        organizationBar.maxValue = TurnMain.Instance.GetCurrentPlayer().organizationBase;
        organizationBar.value = TurnMain.Instance.GetCurrentPlayer().organization;

        if (TurnMain.Instance.playerList[TurnMain.Instance.turn].organization < 0) TurnMain.Instance.playerList[TurnMain.Instance.turn].organization = 0;
    }

    public void OrgInBattleUppdate()
    {
        if (BattleManager.Instance.turn == 0) 
        {
            text.text = "Organization " + BattleManager.Instance.player1.organization + "/" + BattleManager.Instance.player1.organizationBase;
        }
        else
        {
            text.text = "Organization " + BattleManager.Instance.player2.organization + "/" + BattleManager.Instance.player2.organizationBase;
        }

    }


}
