using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour, IShowUI
{
    public Player player1;
    public Player player2;

    public Player dangeonMaster;

    public ScrollManager scrollManager;
    public InventoryScroll inventoryScroll;
    public OrganizationManager organizationManager;

    [SerializeField] private List<LineController> lineControllers;

    public EscapeButton escButton;

    public Text manaText1;
    public Text manaText2;

    public EventType eventType;

    public int escapeAllower = 1;

    public int turn = 0;

    public bool healthSet = false;

    public static BattleManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {

        if (player1.Mana > player1.manaBase) player1.Mana = player1.manaBase;
        if (player2.Mana > player2.manaBase) player2.Mana = player2.manaBase;

        print("start");
        InitPlayers();
        print("init");

        organizationManager.OrgInBattleUppdate();

        //if (eventType == EventType.Raid) player2 = dangeonMaster;

        foreach (UnitBase unit in player1.units)
        {
            scrollManager.AddUnitCards(unit, unit.GetImage());
        }
        foreach (UnitBase unit in player2.units)
        {
            scrollManager.AddUnitCardsEnemy(unit, unit.GetImage());
        }

        escButton.UI_Update();

        foreach (ItemBase item in GetCurPlayer().items)
        {
            inventoryScroll.AddModCards(item, item.GetImage());
        }

        Ui_Update();
    }

    private void InitPlayers()
    {
        
        GameVariables variables = GameVariables.Get();

        player1 = Player.GetPlayer(variables.curplayer);
        player2 = Player.GetPlayer(variables.enemyPlayer);
        //dangeonMaster = Player.GetPlayer(4);
        InitPlayerItems(player1);
        InitPlayerItems(player2);

        manaText1.text = "Mana " + player1.Mana + "/" + player1.manaBase;
        manaText2.text = "Mana " + player2.Mana + "/" + player2.manaBase;

        //EventController.EventGet();
        //Debug.Log("player1" + player1.charecterType);

        //for (int i = 0; i < 3; i++)
        //{
        //    if (i != variables.curplayer && i != variables.enemyPlayer) player3 = Player.GetPlayer(i);
        //}
    }
    private void InitPlayerItems(Player player)
    {
        foreach (ItemBase item in player.items)
        {
            item.parent = player;
        }
    }

    public Player GetCurPlayer()
    {
        if (turn == 0)
        {
            return player1;
        }
        else
        {
            return player2;
        }
    }
    public Player GetCurEnemy()
    {
        if (turn == 0)
        {
            return player2;
        }
        else
        {
            return player1;
        }
    }

    public void SetNextPlayer(float timeWait)
    {
        Invoke("SetNextPlayer", timeWait);
        
        
        
    }
    public void SetNextPlayer()
    {
        inventoryScroll.ClearUnitCards();
        turn++;
        if (turn > 1) turn = 0;
        
        foreach (ItemBase item in GetCurPlayer().items)
        {
            inventoryScroll.AddModCards(item, item.GetImage());
        }
        
        organizationManager.OrgInBattleUppdate();

        healthSet = true;
        
        StatisticUtil.Instace.action = StatisticUtil.Action.Empty;
        CellController.ResetActive();
        WinBattle.Instance.Defeat();

        escapeAllower = 1;
        healthSet = true;

        manaText1.text = "Mana " + player1.Mana + "/" + player1.manaBase;
        manaText2.text = "Mana " + player2.Mana + "/" + player2.manaBase;

        //player1.SavePlayer();
        //player2.SavePlayer();

        inventoryScroll.gameObject.SetActive(false);
        escButton.UI_Update();
        Ui_Update();
    }
    public void Ui_Update()
    {
        foreach (CellController cell in scrollManager.cells)
        {
            cell.StaminAppdate();
        }
        foreach(LineController lineController in lineControllers)
        {
            lineController.UITextUpdate();
        }
    }

    public bool CheckCurPlayer(Player player) 
    {
        if(turn == 0)
        {
            return player.charecterType == player1.charecterType;
        }
        else
        {
            return player.charecterType == player2.charecterType;
        }
    }

    void IShowUI.ShowHideUnitsUI(bool show)
    {
        foreach (UnitBase unit in player1.units)
        {
            unit.cellController.ShowStats(show);
        }
        foreach (UnitBase unit in player2.units)
        {
            unit.cellController.ShowStats(show);
        }
    }
}
