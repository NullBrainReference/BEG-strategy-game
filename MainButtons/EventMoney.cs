using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventMoney : MonoBehaviour
{
    public Text ValueText;
    private void Start()
    {
        //ValueText.text = "Money " + "(+"+ (15 * RegionsController.Instance.GetCurrentRegion().rich).ToString() + ")";
        ValueText.text = "Money " + "(+" + (15 * RegionsController.Instance.GetCurrentRegion().rich).ToString() + ")";
    }
    public void EventNewMoney()
    {
        TurnMain.Instance.GetCurrentPlayer().money += 15 * RegionsController.Instance.GetCurrentRegion().rich;
    
        //TurnMain.Instance.GetCurrentPlayer().SavePlayer();
        TurnMain.Instance.Turner(true);
    }
}
