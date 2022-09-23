using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBooster : ModificatorBase
{

    public DamageBooster()
    {
        effecType = EffecType.DamageBooster;
        valueType = ValueType.Factor;

        damage = 1.5f;
        manaCost = 15;
    }

}
