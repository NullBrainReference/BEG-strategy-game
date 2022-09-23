using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModController : MonoBehaviour
{
    public GameObject itemCell;

    public ItemBase itemBase;
    public Image background;
    public Image border;
    public Text nameText;
    public Text descriptionText;
    public Button abillityButton;

    public static ModController cellActive;

    
    public void SetValues(ItemBase item, Sprite sprite)
    {
        nameText.text = item.name.ToString();
        background.sprite = sprite;
        itemBase = item;
        item.controller = this;

    }
    public void SetOnUse()
    {
        if (BattleManager.Instance.CheckCurPlayer(this.itemBase.parent))
        {
            if (StatisticUtil.Instace.action == StatisticUtil.Action.Empty || StatisticUtil.Instace.action == StatisticUtil.Action.Use || StatisticUtil.Instace.action == StatisticUtil.Action.Select)
            {
                ResetCell();
                StatisticUtil.Instace.action = StatisticUtil.Action.Use;
                StatisticUtil.Instace.modController = this;
                cellActive = this;
                border.gameObject.SetActive(true);
                if (StatisticUtil.Instace.curCell != null) 
                { 
                    StatisticUtil.Instace.curCell.ResetCell(); 
                }
            }
        }
    }
    public void MakeAction(UnitBase unitBase)
    {
        itemBase.MakeAction(unitBase);
        itemBase.parent.items.Remove(this.itemBase);
    }
    public void ResetCell()
    {
        if (cellActive == null) return;
        if (cellActive?.border == null) return;
        cellActive.border.gameObject.SetActive(false);
        this.border.gameObject.SetActive(false);
    }


}
