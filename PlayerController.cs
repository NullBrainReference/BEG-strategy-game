using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharecterType { empty, Mage, Assasin, King, Sniper, DangeonMaster }

public class PlayerController : MonoBehaviour
{
    public Color color;
    public string nextScene;
    public Player player;

    private void Start()
    {
        //dangeonMaster.SavePlayer(4);
    }

    public void SetCherType(int _charType)
    {
        int number = TurnController.Instance.curPlayer;

        if ((CharecterType)_charType == CharecterType.Mage)
        {
            List<UnitBase> units = new List<UnitBase>() { new UnitHeroMage()};
            //Debug.Log("UnitType1=" + units[0].ToString());
            List<ModificatorBase> mods = new List<ModificatorBase>();
            player = new Player(CharecterType.Mage, number, 1, 3, 200, 5, units, mods, 100, 100, 5);
        }
        if ((CharecterType)_charType == CharecterType.Assasin)
        {
            List<UnitBase> units = new List<UnitBase>() { new UnitHeroAssasin()};
            //Debug.Log("UnitType1=" + units[0].ToString());
            List<ModificatorBase> mods = new List<ModificatorBase>();
            player = new Player(CharecterType.Assasin, number, 5, 5, 100, 5, units, mods, 100, 100, 5);
        }
        if ((CharecterType)_charType == CharecterType.King)
        {
            List<UnitBase> units = new List<UnitBase>() { new UnitHeroKing(), new UnitMilitary()};
            Debug.Log("UnitType1=" + units[0].ToString());
            List<ModificatorBase> mods = new List<ModificatorBase>();
            player = new Player(CharecterType.King, number, 3, 1, 0, 0, units, mods, 100, 100, 9);
        }
        if ((CharecterType)_charType == CharecterType.Sniper)
        {
            List<UnitBase> units = new List<UnitBase>() { new UnitHeroSniper()};
            Debug.Log("UnitType1=" + units[0].unitType.ToString());
            List<ModificatorBase> mods = new List<ModificatorBase>();
            player = new Player(CharecterType.Sniper, number, 5, 5, 0, 0, units, mods, 100, 100, 5);
        }
    }

    public void NextPlayer()
    {
        GameObject gameController = GameObject.FindGameObjectWithTag("GameController");
        TurnController turnController = gameController.GetComponent<TurnController>();
        turnController.NextPlayer(nextScene);
    }


}
