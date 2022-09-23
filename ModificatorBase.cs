using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class ModificatorBase //:IModificator
{
    public string description;
    public string name;
    public int id;

    public enum ModType {Empty ,MageResist, PhisicalResist }

    public enum EffecType {Bomb, Anigilator, Heal, ManaBooster, HealthBooster, DamageBooster}

    public enum ValueType {Absolution, Factor }

    //public bool aura;

    public ValueType valueType;
    public ModType modType;
    public EffecType effecType;

    //public bool usable;

    public int shopPrice;
    public float resist;
    public float damage;
    public float manaCost;
    public float health;

    public virtual float GetValue(Player player)
    {
        throw new NotImplementedException("реализовать в потомке"); 
    }
    public virtual float GetValue(UnitBase unitBase)
    {
        throw new NotImplementedException("реализовать в потомке");
    }

    public float value;
    //public float timer;

    internal Player parent;

    public ModController modController;

    public virtual void Ability(Player player)
    {

    }
    public virtual void Ability(UnitBase unitBase)
    {

    }

    public virtual float GetManaMod()
    {
        return 0;
    }

    public ModificatorBase ItemTypeCorrector()
    {
        if (effecType == EffecType.Bomb) return new Bomb();

        return null;
    }
    public virtual Sprite GetImage()
    {
        var sprite = Resources.Load<Sprite>("Default");
        //Image image = Resources.Load("Default") as Image;
        //Debug.Log("UB.GI");

        return sprite;
    }

    public float Value(object obj)
    {
        return value;
    }

    public bool ForUnit(object obj)
    {
        throw new NotImplementedException();
    }
}
