using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHideUIButton : MonoBehaviour
{
    public bool showStats = false;
    [SerializeField]public IShowUI showUI;

    private void Start()
    {
        try
        {
            if (TurnMain.Instance != null)
            {
                showUI = TurnMain.Instance;
            }
            else if (BattleManager.Instance != null)
            {
                showUI = BattleManager.Instance;
            }
        }
        catch
        {

        }
    }

    public void OnClick()
    {
        showStats = !showStats;
        showUI.ShowHideUnitsUI(showStats);
    }
}
