using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegionBase
{
    public string name;
    public int number;
    public int rich;
    public UnitType unitType;

    public List<Player> players;
    [SerializeField]public List<ItemBase> shopItems;

    public RegionBase()
    {
        //shopItems = new List<ItemBase> { };
        players = new List<Player> { };
    }

    public RegionBase(int rich, UnitType unitType)
    {
        this.unitType = unitType;
        this.rich = rich;
    }
    public void SaveRegion()
    {
        List<UnitBase> localUnits = new List<UnitBase> { };
        foreach(Player player in players)
        {
            localUnits.AddRange(player.units);
            player.units = new List<UnitBase> { };
        }
        string regionString = JsonUtility.ToJson(this);

        PlayerPrefs.SetString("Region" + this.number, regionString);
        Debug.Log("Region Saved");

        foreach (Player player in players)
        {
            foreach (UnitBase unit in localUnits)
            {
                if(unit.parent.nomber == player.nomber)
                player.units.Add(unit);
            }
        }
    }
    public static RegionBase GetRegion(int number)
    {
        string regionString = PlayerPrefs.GetString("Region" + number);
        RegionBase regionBase = JsonUtility.FromJson<RegionBase>(regionString);

        return regionBase;
    }
}
