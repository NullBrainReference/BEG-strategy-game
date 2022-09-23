using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    //public List<GameObject> buttonPrefs;

    public GameObject buttonAnomaly;
    public GameObject buttonBattle;
    public GameObject buttonProvision;
    public GameObject buttonMoney;
    public GameObject buttonManaBoost;

    //public Transform button1Parent;
    //public Transform button2Parent;

    public static ButtonManager Instance { get; private set; } 

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        //CreateNewButtons();
    }

    public void CreateNewButtons()
    {
    //    foreach(Transform child in transform)
    //    {
    //        Destroy(child.gameObject);
    //    }
    //
    //    int b1 = Random.Range(0, buttonPrefs.Count);
    //    int b2 = -1;
    //
    //    if (buttonPrefs[b1].name == "ButtonItemAnomaly" && TurnMain.Instance.anomalyCoolDown > 1)
    //    {
    //        while(buttonPrefs[b1].name == "ButtonItemAnomaly")
    //        {
    //            b1 = Random.Range(0, buttonPrefs.Count);
    //        }
    //    }
    //    while ((b1 == b2 || b2 == -1) || (TurnMain.Instance.anomalyCoolDown > 1 && buttonPrefs[b2].name == "ButtonItemAnomaly")||
    //        (b1 == b2 || b2 == -1) && (TurnMain.Instance.anomalyCoolDown < 1 ))
    //    {
    //        b2 = Random.Range(0, buttonPrefs.Count);
    //    }
    //
    //    Instantiate(buttonPrefs[b1], transform);
    //    Instantiate(buttonPrefs[b2], transform);
    //
    }
    public void CreateNewButtons(Player player)
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        //int rnd = Random.Range(0, 100);
        switch (player.RegAction)
        {
            case RegionAction.Money:
                Instantiate(buttonMoney, transform);
                Instantiate(buttonProvision, transform);
                break;
            case RegionAction.Patrol:
                if (TurnMain.Instance.anomalyCoolDown < 1) Instantiate(buttonAnomaly, transform);
                if (RegionsController.Instance.GetCurrentRegion().players.Count >= 2) Instantiate(buttonBattle, transform);
                break;
        }
    }
    public void DestroyButtons()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
}
