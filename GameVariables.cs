using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameVariables 
{
    public bool isFromBattle;
    public int curplayer;
    public int enemyPlayer;
    public int anomalyCooldown;
    public int gameStage;

    public int playerCount;
    public void Save()
    {
        string varString = JsonUtility.ToJson(this);

        PlayerPrefs.SetString("GameVariables", varString);
    }

    public static GameVariables Get()
    {
        
        string varString = PlayerPrefs.GetString("GameVariables");
        //Debug.Log(varString);
        GameVariables lll= JsonUtility.FromJson<GameVariables>(varString);

        return lll;
    }
}
