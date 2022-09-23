using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EscapeButton : MonoBehaviour
{
    [SerializeField] private Text escText;
    [SerializeField] private GameObject mask;
    private float x = 0;

    void Start()
    {
        
    }

    public void BattleEscaper()
    {
        if (!BattleManager.Instance.GetCurPlayer().escapeAbillity) BattleManager.Instance.escapeAllower--;

        if (BattleManager.Instance.escapeAllower != 1)
        {
            mask.SetActive(true);
            return;
        }

        BattleManager.Instance.GetCurPlayer().OrganizationLose();
        BattleManager.Instance.escapeAllower--;
        
        if (BattleManager.Instance.turn == 0)
        {
            x = Random.Range(0, 100 + 8 * BattleManager.Instance.player1.luck - 3 * (BattleManager.Instance.player1.units.Count - 1));
        }
        else
        {
            x = Random.Range(0, 100 + 8 * BattleManager.Instance.player2.luck - 3 * (BattleManager.Instance.player1.units.Count - 1));
        }

        if (x > 90)
        {
            GameVariables gameVariables = GameVariables.Get();
            gameVariables.isFromBattle = true;
            BattleManager.Instance.player1.SavePlayer();
            BattleManager.Instance.player2.SavePlayer();
            gameVariables.Save();
            SceneManager.LoadScene("MainScene3", LoadSceneMode.Single);
        }
        mask.SetActive(true);
    }
    public void UI_Update()
    {
        if (!BattleManager.Instance.GetCurPlayer().escapeAbillity) BattleManager.Instance.escapeAllower--;

        if (BattleManager.Instance.escapeAllower == 1) mask.SetActive(false);
        else mask.SetActive(true);

        if (BattleManager.Instance.turn == 0)
        {
            escText.text = "Escape chance = " + ((1 - (90 / (100 + 8 * BattleManager.Instance.player1.luck - 3 * (BattleManager.Instance.player1.units.Count - 1)))) * 100).ToString("F0") + "%";
        }
        else
        {
            escText.text = "Escape chance = " + ((1 - (90 / (100 + 8 * BattleManager.Instance.player2.luck - 3 * (BattleManager.Instance.player2.units.Count - 1)))) * 100).ToString("f0") + "%";
        }
    }
}
