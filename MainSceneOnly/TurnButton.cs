using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnButton : MonoBehaviour
{
    public void OnClick()
    {
        if (TurnMain.Instance.GetCurrentPlayer().RegAction != RegionAction.Non)
            TurnMain.Instance.Turner(true);
    }
}
