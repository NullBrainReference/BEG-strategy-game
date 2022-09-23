using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellController : MonoBehaviour
{
    public UnitBase unitBase;
    public Text healthText;
    public Text damageText;
    public Text nameText;
    public Button ultimateButton;
    public Image background;
    public Image border;
    public Slider staminaBar;
    public Image nameUI;

    [SerializeField] private GameObject uiPanel;
    [SerializeField] private Image magicalRezistUI;
    [SerializeField] private Image phisicalRezistUI;
    [SerializeField] private Image movementUI;
    [SerializeField] private Image rangeUI;
    [SerializeField] private Text mageRzistText;
    [SerializeField] private Text phisRezistText;
    [SerializeField] private Text movementText;
    [SerializeField] private Text rangeText;

    [SerializeField] private Text staminaText;

    public static CellController cellActive;
    public static CellController cellActiveAtack;
    public static CellController cellActiveAtackOld;
    public GameObject cell;
    public Player lastPlayer;
    public bool isDead = false;


    public void Update()
    {
        if (Input.GetKey(KeyCode.H))
        {
            ShowStats(true);
        }
        else if(Input.GetKeyUp(KeyCode.H))
        {
            ShowStats(false);
        }
    }
    public void ShowStats(bool show)
    {
        if (show)
        {
            uiPanel.SetActive(true);
            magicalRezistUI.gameObject.SetActive(true);
            phisicalRezistUI.gameObject.SetActive(true);
            movementUI.gameObject.SetActive(true);
            rangeUI.gameObject.SetActive(true);
            staminaText.gameObject.SetActive(true);
        }
        else
        {
            uiPanel.SetActive(false);
            magicalRezistUI.gameObject.SetActive(false);
            phisicalRezistUI.gameObject.SetActive(false);
            movementUI.gameObject.SetActive(false);
            rangeUI.gameObject.SetActive(false);
            staminaText.gameObject.SetActive(false);
        }
    }
    public void UltiButtonClick()
    {
        try
        {
            this.unitBase.AbilityApply(BattleManager.Instance.GetCurEnemy());
            BattleManager.Instance.scrollManager.UnitsUpdate();
        }
        catch 
        {
            this.unitBase.AbilityApply(this.unitBase.parent);
        }
        //foreach (UnitBase unit in BattleManager.Instance.GetCurEnemy().units)
        //{
        //    if (unit.realHealth <= 0) Kill(unit);
        //}
    }
    public void KillSelf()
    {
        if (this.unitBase.realHealth <= 0 && this.isDead == false) Kill(this.unitBase);
    }
    public void SetValues(UnitBase unit, Sprite sprite)
    {
        switch (unit.parent.charecterType) 
        {
            case CharecterType.Mage:
                nameUI.color = new Color(255, 255, 0, 0.5f);
                break;
            case CharecterType.Assasin:
                nameUI.color = new Color(255, 0, 255, 0.5f);
                break;
            case CharecterType.King:
                nameUI.color = new Color(0, 255, 255, 0.5f);
                break;
            case CharecterType.Sniper:
                nameUI.color = new Color(0, 0, 255, 0.5f);
                break;
        }
        if (unit.unitType == UnitType.HeroAssasin || unit.unitType == UnitType.HeroKing || unit.unitType == UnitType.HeroMage) ultimateButton.gameObject.SetActive(true);
        else ultimateButton.gameObject.SetActive(false);

        healthText.text = unit.realHealth.ToString("0");
        nameText.text = unit.name;
        damageText.text = unit.Damage.ToString();
        mageRzistText.text = unit.GetMagicRezist().ToString();
        phisRezistText.text = unit.GetPhisicalRezist().ToString();
        rangeText.text = unit.rangedAttack.ToString();
        movementText.text = unit.speed.ToString();
        staminaText.text = unit.staminaBase.ToString();

        ultimateButton.enabled = unit.unitType == UnitType.HeroMage || unit.unitType == UnitType.HeroKing || unit.unitType == UnitType.HeroAssasin;
        Debug.Log("setV=");
        background.sprite = sprite;
        unitBase = unit;
        unit.cellController = this;
        staminaBar.maxValue = unit.staminaBase;
        staminaBar.value = unit.stamina;
    }
    public void StaminAppdate()
    {
        unitBase.stamina = unitBase.stamina + (unitBase.staminaBase - unitBase.stamina) * 0.1f;
        staminaBar.value = unitBase.stamina;
    }
    public void UpdateValues(UnitBase unit)
    {
        healthText.text = unit.realHealth.ToString("0");
        staminaBar.value = unit.stamina;
        if (cellActive == null) cellActive = this;
        cellActive.healthText.text = cellActive.unitBase.realHealth.ToString("0");
        cellActive.staminaBar.value = cellActive.unitBase.stamina;
    }
    public void UpdateValues()
    {
        healthText.text = unitBase.realHealth.ToString("0");
        staminaBar.value = unitBase.stamina;
    }
    //public void UpdateValues(UnitBase unit)
    //{
    //unitBase.realHealth.
    //    healthText.text = unitBase.realHealth.ToString();
    //    staminaBar.value = unitBase.stamina;
    //}
    public void SetActive()
    {
        if (BattleManager.Instance.CheckCurPlayer(this.unitBase.parent))
        {
            if (StatisticUtil.Instace.action == StatisticUtil.Action.Empty || StatisticUtil.Instace.action == StatisticUtil.Action.Select || StatisticUtil.Instace.action == StatisticUtil.Action.Use)
            {
                StatisticUtil.Instace.action = StatisticUtil.Action.Select;
                ResetActive();
                cellActive = this;
                print("CellActive" + cellActive.unitBase.parent.charecterType);
                border.gameObject.SetActive(true);
                StatisticUtil.Instace.curCell = this;
                if (StatisticUtil.Instace.modController != null)
                {
                    StatisticUtil.Instace.modController.ResetCell();
                }
            }
        }
        else if (StatisticUtil.Instace.action == StatisticUtil.Action.Select)
        {
            StatisticUtil.Instace.action = StatisticUtil.Action.Atack;
            print("AtackPlayerNo" + BattleManager.Instance.turn);
            SeToAtack();
            StatisticUtil.Instace.playerNo = BattleManager.Instance.turn;
        }
        else if(StatisticUtil.Instace.action == StatisticUtil.Action.Use)
        {
            StatisticUtil.Instace.modController.MakeAction(this.unitBase);

            StatisticUtil.Instace.playerNo = BattleManager.Instance.turn;
            UpdateValues(this.unitBase);
            if (this.unitBase.realHealth <= 0) Kill(this.unitBase);
            BattleManager.Instance.SetNextPlayer(1);
        }
    }
    public static void ResetActive()
    {
        if (cellActive == null) return;
        if (cellActive?.border == null) return;
        cellActive.border.gameObject.SetActive(false);
        if (cellActiveAtack?.border == null) return;
        cellActiveAtack?.border.gameObject.SetActive(false);
    }
    public void ResetCell()
    {
        if (cellActive == null) return;
        if (cellActive?.border == null) return;
        cellActive.border.gameObject.SetActive(false);
        if (cellActiveAtack?.border == null) return;
        cellActiveAtack?.border.gameObject.SetActive(false);
    }
    public bool SeToAtack()
    {
        cellActiveAtack = this;
        LineController lineParent1 = cellActive.transform.parent.GetComponent<LineController>();
        LineController lineParent2 = cellActiveAtack.transform.parent.GetComponent<LineController>();
        int range = Mathf.Abs(lineParent1.lineNo - lineParent2.lineNo);
        if(cellActive.unitBase.rangedAttack < range)
        {
            StatisticUtil.Instace.action = StatisticUtil.Action.Select;
            return false;
        }
        Animator animator = GetComponent<Animator>();
        cellActiveAtack.border.gameObject.SetActive(true);
        cellActiveAtack.unitBase.Atack(cellActive.unitBase);
        UpdateValues(cellActiveAtack.unitBase);
        if (cellActiveAtack.unitBase.Health != 0)
        {
            animator.Rebind();
            animator.Play("CellBorderAnimation");
        }
        BattleManager.Instance.SetNextPlayer(1);
        return true;
    }
    public void Kill(UnitBase unitBase)
    {
        unitBase.cellController.isDead = true;
        Animator animator = unitBase.cellController.GetComponent<Animator>();
        animator.Rebind();
        animator.Play("Death Animation");
        unitBase.parent.units.Remove(unitBase);
        Destroy(unitBase.cellController.gameObject, 2);
        unitBase.parent.SavePlayer();
    }
}
