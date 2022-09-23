using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemShop : MonoBehaviour
{
    [SerializeField] private GameObject shopPanel;

    [SerializeField] private GameObject dagonPrefab;
    [SerializeField] private GameObject manaStonePrefab;
    [SerializeField] private GameObject chaserPrefab;

    private void OnEnable()
    {
        LoadRegionItems();
    }
    public void LoadRegionItems()
    {
        foreach (Transform trans in shopPanel.transform)
        {
            Destroy(trans.gameObject);
        }

        foreach (ItemBase item in RegionsController.Instance.GetCurrentRegion().shopItems)
        {
            GameObject newObject;
            switch (item.itemType)
            {
                case ItemType.Dagon:
                    newObject = Instantiate(dagonPrefab, shopPanel.transform);
                    DagonShop dagon = newObject.GetComponent<DagonShop>();
                    dagon.itemBase = item;
                    break;
                case ItemType.ManaStone:
                    newObject = Instantiate(manaStonePrefab, shopPanel.transform);
                    ManaBoosterShop manaBooster = newObject.GetComponent<ManaBoosterShop>();
                    manaBooster.itemBase = item;
                    break;
                case ItemType.Chaser:
                    newObject = Instantiate(chaserPrefab, shopPanel.transform);
                    ChaserShop chaser = newObject.GetComponent<ChaserShop>();
                    chaser.itemBase = item;
                    break;
            }   
        }

    }
}
