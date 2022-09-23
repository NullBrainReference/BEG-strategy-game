using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TurnMain : MonoBehaviour, IShowUI
{
    public List<Player> playerList;

    public int counter = 0;
    public int turn = 0;

    private int gameStage = 0;
    public int GameStage { get { return gameStage; } 
        set {
            if (value > 1)
            {
                gameStage = 0;
                RegionsController.Instance.DropPlayers();
                ResetPlayerAction();
            }
            if (value <= 1) gameStage = value;
        } 
    } 

    public int anomalyCoolDown = 0;

    public GameObject defeatScreen;
    public Text defeatText;

    //public Player player;
    //public ButtonManager buttonManager;
    public ScrollManager scrollManager;
    public InventoryScroll inventoryScroll;
    public OrganizationManager organizationManager;
    public ManaBarController manaBarController;
    public UnitCountBar unitCountBar;
    public AnomalyCoolDownIcon anomalyIcon;
    public Text actionText;
    public Text MoneyText;
    public GameObject turnButtonMask;
    public int saveCounter = 0;

    public GameObject scrollContent;

    public static TurnMain Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        //Player.GetPlayer(turn);
        GameVariables gameVariables = GameVariables.Get();
        if (gameVariables.curplayer++ < gameVariables.playerCount && gameVariables.isFromBattle)
        {
            turn = gameVariables.curplayer++;
            gameStage = 1;
        }
        switch (GameStage) 
        {
            case 0:
                RegionsController.Instance.ControllersShow();
                break;
            case 1:
                RegionsController.Instance.ControllersHide();
                break;
        }
        PlayerListUploader(gameVariables);

        Debug.Log("TEST_NewLOGIC");
        foreach (Player pl in playerList)
        {
            //Debug.Log(pl.charecterType + " " + pl.units.Count);
            foreach (UnitBase unit in pl.units)
            {
                //Debug.Log(unit.GetImage().name);
                scrollManager.AddUnitCards(unit, unit.GetImage());
            }
        }

        if (!RegionsController.Instance.PlayersInRegionsCheck())
        {
            foreach (Player player in playerList)
            {
                RegionsController.Instance.PlacePlayerBack(player);
            }
        }

        gameVariables.curplayer = turn;
        gameVariables.isFromBattle = false;
        gameVariables.Save();

        Turner(false);
    }

    public void Turner()
    {
        Turner(true);
    }

    public void Turner(bool addTurn)
    {
        GameVariables gameVariables = GameVariables.Get();
        //gameVariables.curplayer = turn;
        //gameVariables.isFromBattle = false;
        //gameVariables.Save();

        //PlayerListUploader(gameVariables);

        //if (!RegionsController.Instance.PlayersInRegionsCheck())
        //{
        //    foreach (Player player in playerList)
        //    {
        //        RegionsController.Instance.PlacePlayerBack(player);
        //    }
        //}

        if (counter == 1)
        {
            defeatScreen.SetActive(true);
            defeatText.text = playerList[0].charecterType.ToString() + " Won";
        }
        if (addTurn == true) turn++;
        if (turn > (playerList.Count - 1))
        {
            GameStage++;
            turn = 0;
            if (GameStage == 0) RegionsController.Instance.ControllersShow();
            else if (GameStage == 1) RegionsController.Instance.ControllersHide();
        }
        if (playerList[turn].units.Count == 0)
        {
            Turner(true);
        }

        UI_Update();

        anomalyCoolDown--;
        if(playerList[turn].Mana < playerList[turn].manaBase)
        {
            playerList[turn].Mana += playerList[turn].manaReg;
        }

        if (GameStage == 1)
        {
            ButtonManager.Instance.CreateNewButtons(GetCurrentPlayer());

        }
        if (GameStage == 0)
        {
            RegionsController.Instance.ControllersReset();
            ButtonManager.Instance.DestroyButtons();
        }

        playerList[turn].ManaUpdate();
        //==========================================BigSave====================================================
        if (saveCounter % 10 == 0)
        {
            foreach (RegionConrtoller rg in RegionsController.Instance.regionConrtollers)
            {
                rg.regionBase.SaveRegion();
            }

            playerList[turn].SavePlayer();
        }
        saveCounter++;

        //Debug
        //foreach(RegionConrtoller rg in RegionsController.Instance.regionConrtollers)
        //{
        //    Debug.Log("Reg" + rg.regionBase.number + " playerCount = " + rg.regionBase.players.Count);
        //}
        
    }
    public void BattleSceneLoader()
    {
        SceneManager.LoadScene("BattleScene", LoadSceneMode.Single);
    }
    public void ResetPlayerAction()
    {
        foreach (Player pl in playerList)
        {
            pl.RegAction = RegionAction.Non;
            //pl.SavePlayer();
        }
    }
    public void RegActionUIupdate()
    {
        actionText.text = GetCurrentPlayer().RegAction.ToString();
        if (GetCurrentPlayer().RegAction != RegionAction.Non) 
        {
            turnButtonMask.SetActive(false);
        }
        else
        {
            turnButtonMask.SetActive(true);
        }
    }
    public void PlayerListUploader(GameVariables gameVariables)
    {
        counter = 0;
        playerList.Clear();

        for (int i = 0; i < gameVariables.playerCount; i++)
        {

            Player _player = Player.GetPlayer(i);

            if(_player.units.Count>0) _player.CheckAndPlaceHero();
            //if (playerList.Count == 3)
            //{
            //    playerList[i] = _player;
            //}
            //else
            //{
            if(_player.units.Count > 0) playerList.Add(_player);
            //}
            if (_player.units.Count != 0) counter++;
        }
    }
    public Player GetCurrentPlayer() 
    {
        return playerList[turn];
    }
    public void UI_Update()
    {
        inventoryScroll.ClearUnitCards();
        //scrollManager.ClearUnitCards();
        scrollManager.TurnCurrCards(GetCurrentPlayer());

        RegActionUIupdate();
        MoneyText.text = GetCurrentPlayer().money.ToString();

        organizationManager.OrgUppdate();
        manaBarController.SetMana();
        unitCountBar.SetUnitsCount();
        anomalyIcon.CoolDown_Update();

        Debug.Log("Warning! Scroll content resize hardcode!");
        RectTransform rectTransform = (RectTransform)scrollContent.transform;
        rectTransform.offsetMin = new Vector2(0, 0);
        rectTransform.offsetMax = new Vector2(240 * playerList[turn].units.Count + 5, 0);
        //foreach (UnitBase unit in GetCurrentPlayer().units)
        //{
        //    scrollManager.AddUnitCards(unit, unit.GetImage());
        //
        //}
        foreach(ItemBase item in GetCurrentPlayer().items)
        {
            inventoryScroll.AddModCards(item, item.GetImage());
        }
    }
    void IShowUI.ShowHideUnitsUI(bool show)
    {
        foreach (Player player in playerList)
        {
            foreach(UnitBase unit in player.units)
            {
                unit.cellController.ShowStats(show);
            }
        }
    }
}
