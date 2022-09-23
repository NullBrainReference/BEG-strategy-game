using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCountButton : MonoBehaviour
{
    public int count;
    public PlayerChoseManager choseManager;
    public GameObject countsPanel;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void OnClick()
    {
        TurnController.Instance.playerCount = count;
        choseManager.CreatePlayers();
        countsPanel.SetActive(false);
    }
}
