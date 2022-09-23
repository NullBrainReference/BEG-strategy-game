using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolButton : MonoBehaviour
{
    public void OnClick()
    {
        TurnMain.Instance.GetCurrentPlayer().RegAction = RegionAction.Patrol;
        TurnMain.Instance.RegActionUIupdate();
        //TurnMain.Instance.GetCurrentPlayer().SavePlayer();
    }
}
