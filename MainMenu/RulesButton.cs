using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RulesButton : MonoBehaviour
{
    public GameObject rulesScreen;
    public GameObject titleScreen;
    public void OpenClose()
    {
        if (rulesScreen.activeInHierarchy == true)
        {
            rulesScreen.SetActive(false);
            titleScreen.SetActive(true);
        }
        else
        {
            rulesScreen.SetActive(true);
            titleScreen.SetActive(false);
        }
    }
}
