using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventBattle : MonoBehaviour
{
    //private float x = 0;
    //private float a = -1;
    //private float b = -1;
    //
    //private int player1 = 0;
    //private int player2 = 0;

    public void EventNewBattle()
    {
        //GameVariables gameVariables = GameVariables.Get();
        //float x = 0;
        //float a = -1;
        //float b = -1;
        //int player1 = 0;
        //int player2 = 0;
        //
        //for (int i = 0; i < TurnMain.Instance.playerList.Count; i++ ) 
        //{
        //    if (i != TurnMain.Instance.turn && a == -1)
        //    {
        //        a = TurnMain.Instance.playerList[i].luck;
        //        player1 = i;
        //    }
        //    if (i != TurnMain.Instance.turn && b == -1 && player1 != i)
        //    {
        //        b = TurnMain.Instance.playerList[i].luck;
        //        player2 = i;
        //    } 
        //}
        //
        //x = Random.Range(0, a + b);
        //
        //if(x > a)
        //{
        //    gameVariables.enemyPlayer = player1;
        //}
        //else
        //{
        //    gameVariables.enemyPlayer = player2;
        //}
        //
        //if (TurnMain.Instance.counter == 2)
        //{
        //    for (int i = 0; TurnMain.Instance.playerList.Count > i; i++)
        //    {
        //        if(TurnMain.Instance.playerList[i].charecterType != TurnMain.Instance.GetCurrentPlayer().charecterType && TurnMain.Instance.playerList[i].units.Count > 0)
        //        {
        //            gameVariables.enemyPlayer = i;
        //        }
        //    }
        //}
        //gameVariables.Save();
        //TurnMain.Instance.Turner(false);
        //TurnMain.Instance.BattleSceneLoader();
    }
    public void NewBattle()
    {
        GameVariables gameVariables = GameVariables.Get();

        foreach(Player player in TurnMain.Instance.playerList)
        {
            player.SavePlayer();
        }
        foreach (RegionConrtoller rg in RegionsController.Instance.regionConrtollers)
        {
            rg.regionBase.SaveRegion();
        }

        Player player1 = TurnMain.Instance.GetCurrentPlayer();
        Player player2 = GetEnemy();

        gameVariables.curplayer = player1.nomber;
        gameVariables.enemyPlayer = player2.nomber;
        gameVariables.Save();
        TurnMain.Instance.Turner(false);
        TurnMain.Instance.BattleSceneLoader();
    }
    private Player GetEnemy()
    {
        int line = 0;
        int velocityline = 0;
        List<Player> players = new List<Player> { };
        Player enemy = RegionsController.Instance.GetCurrentRegion().players.Find(x => x.nomber != TurnMain.Instance.GetCurrentPlayer().nomber);

        foreach(Player pl in RegionsController.Instance.GetCurrentRegion().players.FindAll(x => x.nomber != TurnMain.Instance.GetCurrentPlayer().nomber))
        {
            velocityline += pl.secrecy;
            players.Add(pl);
        }

        int value = Random.Range(0, velocityline);

        for (int i = 0; i < players.Count; i++) 
        {
            line += players[i].secrecy; //Необходимо сделать обратное, чем больше скрытность, тем меньше вероятность
            if (value <= line && value >= line - players[i].secrecy) enemy = players[i];
        }

        return enemy;
    }

}
