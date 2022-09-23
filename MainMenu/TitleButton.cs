using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleButton : MonoBehaviour
{
    public GameObject titleScreen;
    public void OpenClose()
    {
        if (titleScreen.activeInHierarchy == true) titleScreen.SetActive(false);
        else titleScreen.SetActive(true);
    }
}
