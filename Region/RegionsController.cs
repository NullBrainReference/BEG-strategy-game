using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegionsController : MonoBehaviour
{
    public GameObject RegionsPanel;
    public GameObject RegionPrefab;

    public List<RegionConrtoller> regionConrtollers;

    public static RegionsController Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
        InitControllers();
    }

    void Start()
    {
        
    }

    private void InitControllers()
    {
        regionConrtollers = new List<RegionConrtoller> { };
        GetRegions();
        regionConrtollers.AddRange(RegionsPanel.transform.GetComponentsInChildren<RegionConrtoller>());
        if (TurnMain.Instance.GameStage == 1) ControllersHide();
    }

    public void PlacePlayerBack(Player player)
    {
        foreach (RegionConrtoller rg in regionConrtollers)
        {
            if (rg.regionBase.number == player.regID)
            {
                rg.regionBase.players.Add(player);
                rg.regionBase.SaveRegion();
            }
        }
    }

    public void RegionsBlocker()
    {
        foreach (RegionConrtoller rg in regionConrtollers)
        {
            if (!rg.IsActive)
            {
                rg.MaskImage.SetActive(true);
                rg.IsBlocked = true;
            }
        }
        
    }

    public void GetRegions()
    {
        for (int i = 0; i < 3; i++)
        {
            GameObject newObject = Instantiate(RegionPrefab, RegionsPanel.transform);
            RegionConrtoller regionConrtoller = newObject.GetComponent<RegionConrtoller>();
            regionConrtoller.regionBase = RegionBase.GetRegion(i);
            //regionConrtollers.Add(regionConrtoller);
        }
    }
    public RegionBase GetCurrentRegion()//некорректно работает
    {
        RegionBase regionBase = new RegionBase();
        foreach (RegionConrtoller rg in regionConrtollers)
        {
            foreach (Player pl in rg.regionBase.players)
            {
                if (pl.nomber == TurnMain.Instance.GetCurrentPlayer().nomber) 
                    regionBase = rg.regionBase;
            }
        }
        return regionBase;
    }
    public void DropPlayers()
    {
        foreach (RegionConrtoller rg in regionConrtollers)
        {
            rg.regionBase.players = new List<Player> { };
            //rg.regionBase.SaveRegion();
        }
        foreach (Player player in TurnMain.Instance.playerList)
        {
            player.regID = -1;
            //player.SavePlayer();
        }
    }
    public void ControllersReset()
    {
        foreach (RegionConrtoller rg in regionConrtollers) rg.ControllerReset();
    }
    public void ControllersHide()
    {
        foreach (RegionConrtoller rg in regionConrtollers) rg.TurnOff();
    }
    public void ControllersShow()
    {
        foreach (RegionConrtoller rg in regionConrtollers) rg.TurnOn();
    }
    public RegionBase GetOldRegion(int playerNum)
    {
        RegionBase regionBase = new RegionBase();
        foreach (RegionConrtoller rg in regionConrtollers)
        {
            foreach (Player player in rg.regionBase.players)
            {
                if (player.nomber == playerNum) regionBase = rg.regionBase;
            }
        }
        return regionBase;
    }
    public bool PlayersInRegionsCheck()
    {
        bool inReg = false;

        foreach(RegionConrtoller rg in regionConrtollers)
        {
            if (rg.regionBase.players.Count != 0) inReg = true;
        }
        return inReg;
    } 
}
