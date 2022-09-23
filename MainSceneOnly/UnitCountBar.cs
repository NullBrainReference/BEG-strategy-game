using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitCountBar : MonoBehaviour
{
    public Slider unitBar;
    public Text unitText;

    public void SetUnitsCount()
    {
        unitBar.maxValue = TurnMain.Instance.playerList[TurnMain.Instance.turn].unitLimit;
        unitBar.value = TurnMain.Instance.playerList[TurnMain.Instance.turn].units.Count;

        unitText.text = "Units " + TurnMain.Instance.playerList[TurnMain.Instance.turn].units.Count + "/" + TurnMain.Instance.playerList[TurnMain.Instance.turn].unitLimit;
    }
}
