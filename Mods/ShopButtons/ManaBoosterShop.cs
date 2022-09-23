using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaBoosterShop : MonoBehaviour
{
    public ItemBase itemBase;
    public void OnClick()
    {
        bool buyStatus = TurnMain.Instance.GetCurrentPlayer().BuyItemTransaction(new ManaBooster());
        if(buyStatus)
        {
            TurnMain.Instance.GetCurrentPlayer().manaBase += 100;
            TurnMain.Instance.GetCurrentPlayer().Mana += 100;
            ItemBase copy = itemBase.Copy();
            RegionsController.Instance.GetCurrentRegion().shopItems.Remove(itemBase);
            itemBase = copy;
            //RegionsController.Instance.GetCurrentRegion().SaveRegion();
            TurnMain.Instance.GetCurrentPlayer().SavePlayer();
            TurnMain.Instance.UI_Update();
            ItemShop itemShop = this.GetComponentInParent<ItemShop>();
            itemShop.LoadRegionItems();
        }
    }
}
