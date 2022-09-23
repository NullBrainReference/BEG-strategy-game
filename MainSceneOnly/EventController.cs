using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum EventType { Battle, Item, Raid, Skip };

public class EventController : MonoBehaviour
{
    private float x;

    public EventType eventType;
    public EventType eventTypeOld;

    public TurnMain turnMain;

    void Start()
    {

        GameVariables gameVariables = GameVariables.Get();
        //EventLoader();

    }

    //public void EventLoader()
    //{
    //    GameVariables gameVariables = GameVariables.Get();
    //
    //    //button1.onClick.RemoveAllListeners();
    //    //button2.onClick.RemoveAllListeners();
    //
    //    player = Player.GetPlayer(turnMain.turn);
    //    GetType();
    //    eventTypeOld = eventType;
    //    //присваеваем параметры первой кнопке
    //    //eventType = EventType.Battle;
    //    if (eventType == EventType.Battle)
    //    {
    //        while (gameVariables.enemyPlayer == turnMain.turn || gameVariables.enemyPlayer == 4) gameVariables.enemyPlayer = UnityEngine.Random.Range(0, 2);
    //        //Debug.Log("Rabotaet1");
    //        text1.text = "Battle";
    //        button1.onClick.AddListener(() => { BattleSceneLoader(); });
    //    }
    //    else if (eventType == EventType.Item)
    //    {
    //        //Debug.Log("Rabotaet1");
    //        text1.text = "Archer";
    //        button1.onClick.AddListener(() => { 
    //            player.units.Add(new UnitArchers()); 
    //        });
    //        Debug.Log("Units " + player.units.ToString());
    //
    //    }
    //    else if (eventType == EventType.Raid)
    //    {
    //        //Debug.Log("Rabotaet1");
    //        text1.text = "Raid";
    //
    //        gameVariables.enemyPlayer = 4;
    //
    //
    //        button1.onClick.AddListener(() => { BattleSceneLoader(); });
    //
    //
    //    }
    //    else if (eventType == EventType.Skip)
    //    {
    //        //Debug.Log("Rabotaet1");
    //        text1.text = "skip";
    //        button1.onClick.AddListener(() => { print("skip"); });
    //        
    //    }
    //    //присваеваем параметры второй
    //    while (eventType == eventTypeOld) GetType();
    //    if (eventType == EventType.Battle)
    //    {
    //        //Debug.Log("Rabotaet2");
    //        while (gameVariables.enemyPlayer == turnMain.turn || gameVariables.enemyPlayer == 4) gameVariables.enemyPlayer = UnityEngine.Random.Range(0, 2);
    //        button2.onClick.AddListener(() => { BattleSceneLoader(); });
    //        text2.text = "Battle";
    //    }
    //    else if (eventType == EventType.Item)
    //    {
    //        //Debug.Log("Rabotaet2");
    //        button2.onClick.AddListener(() => {
    //            player.units.Add(new UnitArchers());
    //        });
    //
    //        Debug.Log("Units " + player.units.ToString());
    //        text2.text = "Archer";
    //    }
    //    else if (eventType == EventType.Raid)
    //    {
    //       //Debug.Log("Rabotaet2");
    //        //button2.onClick.AddListener(() => { print("raid"); });
    //
    //        text2.text = "Raid";
    //
    //        gameVariables.enemyPlayer = 4;
    //
    //        button2.onClick.AddListener(() => { BattleSceneLoader(); });
    //    }
    //    else if (eventType == EventType.Skip)
    //    {
    //        //Debug.Log("Rabotaet2");
    //        button2.onClick.AddListener(() => { print("skip"); });
    //        text2.text = "skip";
    //    }
    //    gameVariables.Save();
    //    player.SavePlayer(turnMain.turn);
    //    EventSave();
    //}





    //public void GetType()
    //{
    //    x = UnityEngine.Random.Range(0, 100);
    //    if (x <= 25)
    //    {
    //        eventType = EventType.Battle;
    //    }
    //    if ((x > 25) && (x <= 50))
    //    {
    //        eventType = EventType.Item;
    //    }
    //    if ((x > 50) && (x <= 75))
    //    {
    //        eventType = EventType.Raid;
    //    }
    //    if ((x > 75) && (x <= 100))
    //    {
    //        eventType = EventType.Skip;
    //    }
    //}



    //public void EventSave()
    //{
    //    string eventString = JsonUtility.ToJson(eventType);
    //    PlayerPrefs.SetString("EvenType", eventString);
    //}
    //
    //public static EventType EventGet()
    //{
    //    string eventString = PlayerPrefs.GetString("EvenType");
    //    EventType eventType = JsonUtility.FromJson<EventType>(eventString);
    //
    //    return eventType;
    //}
    //
    //public void EventBattle()
    //{
    //    GameVariables gameVariables = GameVariables.Get();
    //
    //    while (gameVariables.enemyPlayer == turnMain.turn || gameVariables.enemyPlayer == 4) gameVariables.enemyPlayer = UnityEngine.Random.Range(0, 2);
    //    gameVariables.Save();
    //    turnMain.Turner(true);
    //   
    //}
    //
    //public void EventSkip()
    //{
    //    turnMain.Turner(true);
    //
    //}
    //
    //public void EventRaid()
    //{
    //    GameVariables gameVariables = GameVariables.Get();
    //    gameVariables.enemyPlayer = 4;
    //    gameVariables.Save();
    //    turnMain.Turner(true);
    //    
    //}
    //
    //public void EventUnitArcher()
    //{
    //    turnMain.player.units.Add(new UnitArchers());
    //    turnMain.player.SavePlayer(turnMain.turn);
    //    turnMain.Turner(true);
    //}
}
