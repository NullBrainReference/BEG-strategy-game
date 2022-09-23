using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollManager : MonoBehaviour
{
    public GameObject cell;
    public GameObject content;
    public GameObject contentEnemy;

    public GameObject line;

    public List<CellController> cells;

    // Start is called before the first frame update

    private void Awake()
    {
        cells = new List<CellController> { };
    }

    public void AddUnitCards(UnitBase unit, Sprite sprite)
    {
        GameObject newCell = Instantiate(cell, content.transform);
        CellController cellController = newCell.GetComponent<CellController>();

        unit.SetRealHealth(unit.Health);
        unit.stamina = unit.staminaBase;

        if (unit.parent.organization > 0)
        {
            unit.realHealth = unit.realHealth * 0.1f + (unit.realHealth * (unit.parent.organization / unit.parent.organizationBase) * 0.9f);
        }
        else
        {
            unit.realHealth = unit.realHealth * 0.1f;
        }
        cellController.SetValues(unit, sprite);
        cells.Add(cellController);
    }
    public void AddUnitCardsEnemy(UnitBase unit, Sprite sprite)
    {
        GameObject newCell = Instantiate(cell, contentEnemy.transform);
        CellController cellController = newCell.GetComponent<CellController>();

        unit.SetRealHealth(unit.Health);

        if (unit.parent.organization > 0)
        {
            unit.realHealth = unit.realHealth * 0.1f + (unit.realHealth * (unit.parent.organization / unit.parent.organizationBase) * 0.9f);
        }
        else
        {
            unit.realHealth = unit.realHealth * 0.1f;
        }
        cellController.SetValues(unit, sprite);
        cells.Add(cellController);
    }
    public void UnitsUpdate()
    {
        //CellController[] cellControllers = content.GetComponentsInChildren<CellController>();
        
        foreach(CellController cellController in cells)
        {
            cellController.UpdateValues();
        }
        //cellControllers = contentEnemy.GetComponentsInChildren<CellController>();
        //foreach (CellController cellController in cellControllers)
        //{
        //    cellController.UpdateValues();
        //}
    }
    public void UnitsOrgUpdate()
    {
        foreach (CellController cellController in cells)
        {
            Debug.Log(TurnMain.Instance.GetCurrentPlayer().organization + " / " + cellController.unitBase.parent.organization);
            if (cellController.unitBase.parent.nomber == TurnMain.Instance.GetCurrentPlayer().nomber)
            {
                if (cellController.unitBase.parent.organization > 0)
                {
                    cellController.unitBase.realHealth = cellController.unitBase.healthBase * 0.1f +
                        (cellController.unitBase.healthBase * (TurnMain.Instance.GetCurrentPlayer().organization / TurnMain.Instance.GetCurrentPlayer().organizationBase) * 0.9f);
                }
                else
                {
                    cellController.unitBase.realHealth = cellController.unitBase.healthBase * 0.1f;
                }
                cellController.UpdateValues(cellController.unitBase);
            }
        }
    }

        public void ClearUnitCards()
    {
        foreach (Transform trans in content.transform)
        {
            Destroy(trans.gameObject);
        }
    }

    public void TurnCurrCards(Player player)
    {
        foreach(CellController cell in cells)
        {
            if(player.nomber == cell.unitBase.parent.nomber)
                cell.cell.SetActive(true);
            else
                cell.cell.SetActive(false);
        }
    }

    //public void AddCard(UnitBase unit)
    //{
    //    CellController cellController = new CellController();
    //
    //    unit.SetRealHealth(unit.Health);
    //    unit.stamina = unit.staminaBase;
    //
    //    if (unit.parent.organization > 0)
    //    {
    //        unit.realHealth = unit.realHealth * 0.1f + (unit.realHealth * (unit.parent.organization / unit.parent.organizationBase) * 0.9f);
    //    }
    //    else
    //    {
    //        unit.realHealth = unit.realHealth * 0.1f;
    //    }
    //    cellController.SetValues(unit, unit.GetImage());
    //    cells.Add(cellController);
    //}
}
