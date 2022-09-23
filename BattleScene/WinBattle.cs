using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinBattle : MonoBehaviour
{
    public static WinBattle Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }



    void Start()
    {
        
    }

    public void Defeat()
    {
        if (BattleManager.Instance.player1.units.Count == 0  || BattleManager.Instance.player2.units.Count == 0)
        {
            if (BattleManager.Instance.player1.units.Count == 0)
            {

            }

            GameVariables gameVariables = GameVariables.Get();
            gameVariables.isFromBattle = true;
            gameVariables.Save();
            SceneManager.LoadScene("MainScene3", LoadSceneMode.Single);
        }
    }
}
