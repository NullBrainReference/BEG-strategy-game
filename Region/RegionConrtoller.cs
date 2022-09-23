using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegionConrtoller : MonoBehaviour
{
    public RegionBase regionBase;

    public Text richText;
    public Text nameText;
    public Text heroesText;

    public GameObject TitleGroup;
    public GameObject ActionGroup;
    public GameObject RegionGameObject;

    public GameObject MaskImage;

    public bool IsActive { get; private set; }
    public bool IsBlocked { get; set; } = false;
    void Start()
    {
        UIupdate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SwapGroups()
    {// переключение с тайтла на действия
        if (!TitleGroup.activeInHierarchy && !IsBlocked)
        {
            TitleGroup.SetActive(true);
            ActionGroup.SetActive(false);
        }
        else if(!IsBlocked)
        {
            TitleGroup.SetActive(false);
            ActionGroup.SetActive(true);
        }
    }
    public void UIupdate()
    {
        richText.text = "rich "+ regionBase.rich.ToString();
        nameText.text =  regionBase.name;
        heroesText.text = "Heroes in region "+ regionBase.players.Count.ToString();
    }
    public void SetActive()
    {
        IsActive = true;

        RegionsController.Instance.RegionsBlocker();
    }
    private void PlacePlayer()
    {
        regionBase.players.Sort((x,y) => x.nomber.CompareTo(y.nomber));

        if (!CheckPlayerInRegion())
        {
            regionBase.players.Add(TurnMain.Instance.playerList[TurnMain.Instance.turn]);
            TurnMain.Instance.playerList[TurnMain.Instance.turn].regID = regionBase.number;
        }
        //RegionsController.Instance.GetOldRegion(TurnMain.Instance.GetCurrentPlayer().nomber);
    }
    private bool CheckPlayerInRegion()
    {
        return regionBase.players.Exists(x => x.nomber == TurnMain.Instance.GetCurrentPlayer().nomber);
    }
    public void OnClick()
    {
        SwapGroups();
        SetActive();
        PlacePlayer();
    }
    public void ControllerReset()
    {
        TitleGroup.SetActive(true);
        ActionGroup.SetActive(false);
        MaskImage.SetActive(false);

        UIupdate();

        IsActive = false;
        IsBlocked = false;
    }
    public void TurnOn()
    {
        RegionGameObject.SetActive(true);
    }
    public void TurnOff()
    {
        RegionGameObject.SetActive(false);
    }
}
