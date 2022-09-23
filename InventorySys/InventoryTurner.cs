using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryTurner : MonoBehaviour
{
    public GameObject InvertoryBar;

    public void TurnOn()
    {
        if (InvertoryBar.gameObject.activeInHierarchy == true) InvertoryBar.gameObject.SetActive(false);
        else if (InvertoryBar.gameObject.activeInHierarchy == false) InvertoryBar.gameObject.SetActive(true);


    }

}
