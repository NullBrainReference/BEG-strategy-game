using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopButton : MonoBehaviour
{
    public GameObject shopPanel;
    public void OnClick()
    {
        if (shopPanel.activeInHierarchy) shopPanel.SetActive(false);
        else shopPanel.SetActive(true);
    }
}
