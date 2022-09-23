using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum ActionType { Magic, Phisical };
public enum UnitType { HeroMage, HeroKing, HeroAssasin, HeroSniper, Military, Mount, Archers, Pork }

[System.Serializable]
public class UnitBase
{
    public string name;
    public UnitType unitType;
    public float speed;
    public float healthBase;
    public float healthReg;
    public float staminaBase;
    public float stamina;
    public float damageBase;

    public float realHealth;
    public float Health { 
        get
        { 
            return healthBase * GetFactor(TypeFactor.Health); 
        } }

    public float Damage {
        get 
        { 
            return damageBase * GetFactor(TypeFactor.Damage); 
        } }

    public float resistMagical;
    public float resistPhisical;
    public int rangedAttack;
    public ActionType aсtionType;

    public Player parent;
    public CellController cellController;
    public List<ModificatorBase> modificators;
    private enum TypeFactor {Damage, Health }

    public int counter = -1;
    public void SetRealHealth(float _health)
    {
        if (counter == -1)
        {
            realHealth = _health;
            counter++;
        }
    }
    private float GetFactor(TypeFactor typeFactor)
    {
        float result = 1;
    
        if (modificators == null)
        {
            return result;
        }
        List<ModificatorBase> _modificators = modificators.FindAll(x => x.valueType == ModificatorBase.ValueType.Factor);
        foreach (ModificatorBase modificator in _modificators)
        {
            if (modificator.effecType == ModificatorBase.EffecType.DamageBooster) result *= modificator.damage;
            if (modificator.effecType == ModificatorBase.EffecType.HealthBooster) result *= modificator.health;
        }
        return result;
    } 
    
    public UnitBase()
    {

    }
    public UnitBase(UnitBase unitBase)
    {
        name = unitBase.name;
        unitType = unitBase.unitType;
        speed = unitBase.speed;
        healthBase = unitBase.healthBase;
        staminaBase = unitBase.staminaBase;
        stamina = unitBase.stamina;
        healthReg = unitBase.healthReg;
        damageBase = unitBase.damageBase;


        resistMagical = unitBase.resistMagical;
        resistPhisical = unitBase.resistPhisical;
        rangedAttack = unitBase.rangedAttack;
        aсtionType = unitBase.aсtionType;

        parent = unitBase.parent;
    }
    internal void TakeAction(ActionType actionType, float ultimate)
    {
        if (actionType == ActionType.Magic)
        {
            ultimate = ultimate * (1 - resistMagical);
        }
        else if(actionType == ActionType.Phisical)
        {
            ultimate = ultimate * (1 - resistPhisical);
        }
        realHealth -= ultimate;
    }

    public int GetMagicRezist()
    {
        float resist = resistMagical * 100;
        return (int)resist;
    }
    public int GetPhisicalRezist()
    {
        float resist = resistPhisical * 100;
        return (int)resist;
    }

    internal void Atack(UnitBase atacker)
    {
        float damageFactor = 0.7f;
        float manaFactor = 1.0f;
        float staminaRangersFactor = 4f;

        float _resist = 0;
        float staminaDamage = 0;
        float _damage = atacker.Damage;
        float _damageDef = this.Damage;
        //ATACKER'S
        if(atacker.aсtionType == ActionType.Magic)
        {
            _damage = _damage * (1 - resistMagical);
            _resist = resistMagical;
        }
        else
        {
            _damage = _damage * (1 - resistPhisical);
            _resist = resistPhisical;
        }

        //DEFENDER'S
        if(this.aсtionType == ActionType.Magic)
        {
            _damageDef = Damage * (1 - atacker.resistMagical) * damageFactor;
            staminaDamage = Damage;
        }
        else
        {
            _damageDef = Damage * (1 - atacker.resistPhisical) * damageFactor;
            staminaDamage = Damage;
        }

        //HEALTH MATH
        if (atacker.aсtionType == ActionType.Phisical && atacker.rangedAttack == 1)
        {
            //25% base damage + 75% modified with stamina
            realHealth -= Mathf.Abs(_damage * 0.25f + _damage * (atacker.stamina / atacker.staminaBase) * 0.75f);

            this.stamina -= _damageDef * (1 - _resist);
            if (this.rangedAttack > 1)
            {
                this.stamina -= _damageDef * (1 - _resist) * staminaRangersFactor;
            }
            atacker.realHealth -= Mathf.Abs(_damageDef * (atacker.stamina / atacker.staminaBase));
            atacker.stamina -= staminaDamage;
        }
        else if (atacker.aсtionType == ActionType.Phisical && atacker.rangedAttack > 1)
        {
            realHealth -= Mathf.Abs(_damage * 0.1f + _damage * (atacker.stamina / atacker.staminaBase) * 0.9f);
            this.stamina -= _damage;

        }
        else
        {
            realHealth -= Mathf.Abs(_damage * 0.1f + _damage * (atacker.parent.Mana / atacker.parent.manaBase) * 0.9f);
            this.stamina -= _damage * 1.7f;
            atacker.parent.Mana -= _damage * manaFactor;
            if (atacker.parent.Mana < 0) atacker.parent.Mana = 0;
        }

        Debug.Log("_DefD = " + _damageDef * Mathf.Abs(atacker.stamina / atacker.staminaBase));
        Debug.Log("_Damage = " + _damage * 0.25f + _damage * (Mathf.Abs(atacker.stamina / atacker.staminaBase) * 0.75f));

        atacker.parent.Organization -= 0.25f * ((1 - atacker.realHealth / atacker.Health) * (atacker.Health - atacker.realHealth)) / atacker.parent.units.Count;
        this.parent.Organization -= 0.25f * ((1 - this.realHealth / this.Health) * (this.Health - this.realHealth)) / this.parent.units.Count;

        if (this.stamina < 0) this.stamina = 0;
        if (this.realHealth <= 0)
        {
            realHealth = 0;
            cellController.Kill(this);
        }
        if(atacker.realHealth <= 0)
        {
            atacker.realHealth = 0;
            cellController.Kill(atacker);
        }

    }
    public void GetDamage(int damage)
    {
        realHealth -= damage;
    }

    public virtual void AbilityApply(Player other)
    {
        
    }

    public virtual Sprite GetImage()
    {
        var sprite = Resources.Load<Sprite>("Default");
        //Image image = Resources.Load("Default") as Image;
        //Debug.Log("UB.GI");
        if(unitType == UnitType.Military)
        {
            
        }
        return sprite;
    }

    public UnitBase TypeCorrector()
    {
        switch (unitType)
        {
            case UnitType.HeroKing:
                return new UnitHeroKing(this);
            case UnitType.HeroMage:
                return new UnitHeroMage(this);
            case UnitType.HeroSniper:
                return new UnitHeroSniper(this);
            case UnitType.HeroAssasin:
                return new UnitHeroAssasin(this);

            case UnitType.Archers:
                return new UnitArchers(this);
            case UnitType.Military:
                return new UnitMilitary(this);
            case UnitType.Mount:
                return new UnitMount(this);
            case UnitType.Pork:
                return new UnitPork(this);
        }

        Debug.LogError("добавить тип");
        return null;
        
    }
    public static UnitBase GetUnit(UnitType unitType)
    {
        switch (unitType)
        {
            case UnitType.HeroKing:
                return new UnitHeroKing();
            case UnitType.HeroMage:
                return new UnitHeroMage();
            case UnitType.HeroSniper:
                return new UnitHeroSniper();
            case UnitType.HeroAssasin:
                return new UnitHeroAssasin();

            case UnitType.Archers:
                return new UnitArchers();
            case UnitType.Military:
                return new UnitMilitary();
            case UnitType.Mount:
                return new UnitMount();
            case UnitType.Pork:
                return new UnitPork();
        }

        Debug.LogError("добавить тип");
        return null;

    }
}
