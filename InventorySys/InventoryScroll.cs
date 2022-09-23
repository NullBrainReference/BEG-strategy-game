using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScroll : MonoBehaviour
{
    public GameObject cell;
    public GameObject content;

    void Start()
    {
        
    }

    public void AddModCards(ItemBase itemBase, Sprite sprite)
    {
        GameObject newItemCell = Instantiate(cell , content.transform);
        ModController modController = newItemCell.GetComponent<ModController>();
        modController.SetValues(itemBase,sprite);

    }

    public void ClearUnitCards()
    {
        foreach (Transform trans in content.transform)
        {
            Destroy(trans.gameObject);
        }
    }

}
