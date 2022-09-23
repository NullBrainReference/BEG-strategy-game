using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnomalyCoolDownIcon : MonoBehaviour
{
    public Text coolDownText;

    public void CoolDown_Update() 
    {
        if (TurnMain.Instance.anomalyCoolDown < 0) TurnMain.Instance.anomalyCoolDown = 0;
        coolDownText.text = TurnMain.Instance.anomalyCoolDown.ToString();
    }
}
