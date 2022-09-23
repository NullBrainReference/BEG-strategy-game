using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBarController : MonoBehaviour
{
    public Slider manaBar;
    public Text manaText;

    public void SetMana()
    {
        manaBar.maxValue = TurnMain.Instance.playerList[TurnMain.Instance.turn].manaBase;
        manaBar.value = TurnMain.Instance.playerList[TurnMain.Instance.turn].Mana;

        manaText.text = "Mana " + TurnMain.Instance.playerList[TurnMain.Instance.turn].Mana + "/" + TurnMain.Instance.playerList[TurnMain.Instance.turn].manaBase;
    }
}
