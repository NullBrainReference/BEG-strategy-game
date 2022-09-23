using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TurnController : MonoBehaviour
{
    public List<GameObject> players;
    public int curPlayer = 0;
    public Camera cam;
    public int playerCount;

    public static TurnController Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        ButtonLocker.lockNumbers = new List<int> { };
    }


    public void NextPlayer(string nextScene)
    {
        players[curPlayer].SetActive(false);

        PlayerController playerControllerPref = players[curPlayer].GetComponent<PlayerController>();
        Player player = playerControllerPref.player;
        player.SavePlayer();

        curPlayer++;

        if (curPlayer >= players.Count)
        {
            if (nextScene == "")
            {
                curPlayer = 0;
            }
            else
            {
                SaveVar();
                SceneManager.LoadScene(nextScene, LoadSceneMode.Single);
                curPlayer = 0;
            }
        }
            players[curPlayer].SetActive(true);
        PlayerController playerController = players[curPlayer].GetComponent<PlayerController>();
        cam.backgroundColor = playerController.color;

        ButtonLocker buttonLocker = players[curPlayer].GetComponent<ButtonLocker>();
        if(buttonLocker != null)
        {
            buttonLocker.LockButtons();
        }
        Debug.Log("NextPlayer "+ curPlayer);
    }

    private void SaveVar()
    {
        GameVariables variables;
        variables = new GameVariables();
        variables.curplayer = 0;
        variables.playerCount = playerCount;
        //variables.enemyPlayer = 1;
        variables.Save();
    }

}
