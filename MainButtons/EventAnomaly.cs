using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventAnomaly : MonoBehaviour
{
    public void NewAnomaly()
    {
        //TurnMain.Instance.playerList[TurnMain.Instance.turn].modificators.Add(new Anomaly());
        if (TurnMain.Instance.playerList[TurnMain.Instance.turn].Mana >= 600 && TurnMain.Instance.anomalyCoolDown < 1)
        {
            Debug.Log("Player Won");
            TurnMain.Instance.defeatText.text = TurnMain.Instance.playerList[TurnMain.Instance.turn].charecterType.ToString() + " Won";
            TurnMain.Instance.defeatScreen.SetActive(true);
        }
        else TurnMain.Instance.anomalyCoolDown = 6;

        //TurnMain.Instance.playerList[TurnMain.Instance.turn].SavePlayer();
        //TurnMain.Instance.Turner(true);
    }
}
