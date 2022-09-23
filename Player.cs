using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum RegionAction { Non, Money, Patrol }

[System.Serializable]
public class Player
{
    public int nomber;
    public float luck;
    public int secrecy;
    [SerializeField]private float mana;
    public float Mana
    {
        get
        {
            return mana;
        }
        set
        {
            if (value >= manaBase) mana = manaBase;
            else if (value <= 0) mana = 0;
            else mana = value;
        }
    }
    public float Organization {
        get 
        {
            return organization;
        }
        set
        {
            if (value >= organizationBase) organization = organizationBase;
            else if (value <= 0) organization = 0;
            else organization = value;
        }
    }
    public float manaBase;
    public float manaReg;
    public float manaRegBase;
    public List<UnitBase> units;
    public List<ModificatorBase> modificators;
    public List<ItemBase> items;
    public CharecterType charecterType;
    public int unitLimit;
    public float organization;
    public float organizationBase;
    public int money;
    public bool escapeAbillity = true;

    public int regID;
    public RegionAction RegAction;

    [SerializeField] private List<UnitType> unitsReferences;

    public Player(CharecterType _charecterType, int _nomber, float _luck, int _secrecy, float _manaBase, float _manaRegBase,
        List<UnitBase> _units, List<ModificatorBase> _modificators, float _organization, float _organizationBase, int _unitLimit)
    {
        nomber = _nomber;
        luck = _luck;
        //secrecyBase = _secrecyBase;
        manaBase = _manaBase;
        manaRegBase = _manaRegBase;
        charecterType = _charecterType;

        secrecy = _secrecy;
        Mana = _manaBase;
        manaReg = _manaRegBase;
        organization = _organization;
        organizationBase = _organizationBase;

        unitLimit = _unitLimit;

        modificators = _modificators;
        units = _units;
        foreach (UnitBase unit in units)
            unit.parent = this;
        foreach (ModificatorBase mod in modificators)
            mod.parent = this;
        //foreach (ItemBase item in items)
        //    item.parent = this;
    }
    public float GetManaPool()
    {
        return mana;
    }
    public void SavePlayer()
    {
        PlaceUnitsToReferences();
        List<UnitBase> localUnits = units;
        units = null;
        string playerString = JsonUtility.ToJson(this);
#if UNITY_EDITOR
        //TestSave.SaveToFile(playerString, Application.dataPath + @"\Player" + nomber);
#endif
        PlayerPrefs.SetString("Player" + nomber, playerString);
        Debug.Log("PL Saved");
        units = localUnits;
    }
    public static Player GetPlayer(int nomber)
    {
        string playerString = PlayerPrefs.GetString("Player" + nomber);
        Player player = JsonUtility.FromJson<Player>(playerString);
        List<UnitBase> _units = new List<UnitBase>();
        List<ItemBase> _items = new List<ItemBase>();

        //if(player.units.Count>0) player.CheckAndPlaceHero();

        Debug.Log("123");
        //foreach (UnitBase unitBase in player.units)
        //{
        //    unitBase.parent = player;
        //    _units.Add(unitBase.TypeCorrector());
        //}
        foreach (UnitType type in player.unitsReferences)
        {
            UnitBase unit = UnitBase.GetUnit(type);
            unit.parent = player;
            _units.Add(unit.TypeCorrector());
        }
        foreach (ItemBase item in player.items)
        {
            item.parent = player;
            _items.Add(item.TypeCorrector());
        }
        player.units = _units;
        player.items = _items;

        if (player.units.Count > 0)
        {
            player.CheckAndPlaceHero();
            player.units[player.units.Count - 1].parent = player;
        }
        return player;
    }
    public bool UnitLimitCheck()
    {
        bool check = false;
        if (units.Count < unitLimit) check = true;
        return check;
    }
    public void ManaUpdate()
    {
        Mana += manaReg;
    }
    public void BuyItem(ItemBase item)
    {
        if (item.shoPrice <= this.money)
        {
            item.parent = this;
            items.Add(item);
            this.money -= item.shoPrice;
        }
    }
    public bool BuyItemTransaction(ItemBase item)
    {
        bool allowed = false;
        if (item.shoPrice <= this.money)
        {
            item.parent = this;
            items.Add(item);
            this.money -= item.shoPrice;
            allowed = true;
        }
        return allowed;
    }
    private bool HeroDead()
    {
        bool dead = true;
        foreach(UnitBase unit in units)
        {
            if (unit.unitType == UnitType.HeroAssasin || 
                unit.unitType == UnitType.HeroKing || 
                unit.unitType == UnitType.HeroMage || 
                unit.unitType == UnitType.HeroSniper)
                dead = false;
        }
        return dead;
    }
    public void CheckAndPlaceHero()
    {
        if (HeroDead())
        {
            switch (charecterType)
            {
                case CharecterType.Assasin:
                    units.Add(new UnitHeroAssasin());
                    break;
                case CharecterType.King:
                    units.Add(new UnitHeroKing());
                    break;
                case CharecterType.Mage:
                    units.Add(new UnitHeroMage());
                    break;
                case CharecterType.Sniper:
                    units.Add(new UnitHeroSniper());
                    break;
            }
        }
    }
    public void OrganizationLose()
    {
        Organization -= 10 * units.Count;
        SavePlayer();
    }
    public void HealthOrgUpdate()
    {
        foreach(UnitBase unit in units)
        {
            unit.realHealth = 0.1f * unit.realHealth + 0.9f * (Organization / organizationBase) * unit.realHealth;
            unit.cellController.UpdateValues();
        }
    }
    private void PlaceUnitsToReferences()
    {
        unitsReferences = new List<UnitType> { };
        foreach(UnitBase unit in units)
        {
            unitsReferences.Add(unit.unitType);
        }
    }
}
