using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineController : MonoBehaviour
{
    public int p1Count;
    public int p2Count;
    public int lineNo;
    private bool chargeFrontline;

    [SerializeField] private GameObject frontlineIcon;
    [SerializeField] private Text unitsCountText;

    void Start()
    {

    }
    private void SwitchFrontlineIcon(bool isFont)
    {
        //frontlineIcon.SetActive(isFont);
    }
    public void UITextUpdate()
    {
        int count = p1Count + p2Count;
        unitsCountText.text = count.ToString() + "/" + "5";
    }
    public void PasteCard()
    {
        List<CellController> cellControllers = new List<CellController>( GetComponentsInChildren<CellController>());
        p1Count = cellControllers.FindAll(x => x.unitBase.parent == BattleManager.Instance.player1).Count;
        p2Count = cellControllers.FindAll(x => x.unitBase.parent == BattleManager.Instance.player2).Count;

        if (p1Count + p2Count >= 5) return;

        if (StatisticUtil.Instace.action == StatisticUtil.Action.Select)
        {
            LineController lineControllerParent = CellController.cellActive.transform.parent.GetComponent<LineController>();

            int step = Mathf.Abs(lineControllerParent.lineNo - this.lineNo);

            chargeFrontline = true;

            if (step <= CellController.cellActive.unitBase.speed && CellController.cellActive.unitBase.speed > 1)
            {
                StatisticUtil.Instace.action = StatisticUtil.Action.Move;

                try
                {
                    if (BattleManager.Instance.turn == 0)
                    {
                        lineControllerParent.p1Count--;
                        p1Count++;
                    }
                    else
                    {
                        lineControllerParent.p2Count--;
                        p2Count++;
                    }
                }
                catch
                {

                }

                CellController.cellActive.transform.parent = transform;
                CellController.ResetActive();
                BattleManager.Instance.SetNextPlayer();
                StatisticUtil.Instace.playerNo = BattleManager.Instance.turn;
            }
            else if (step <= CellController.cellActive.unitBase.speed && chargeFrontline == true)
            {
                StatisticUtil.Instace.action = StatisticUtil.Action.Move;

                try
                {
                    if (BattleManager.Instance.turn == 1)
                    {
                        lineControllerParent.p1Count--;
                        p1Count++;
                    }
                    else
                    {
                        lineControllerParent.p2Count--;
                        p2Count++;
                    }
                }
                catch
                {

                }

                CellController.cellActive.transform.parent = transform;
                CellController.ResetActive();
                BattleManager.Instance.SetNextPlayer();
                StatisticUtil.Instace.playerNo = BattleManager.Instance.turn;
            }
        }
        UITextUpdate();
        //SwitchFrontlineIcon(!chargeFrontline);
    }
}
