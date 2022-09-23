using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBooster : ModificatorBase
{

    public HealthBooster()
    {
        effecType = EffecType.HealthBooster;
        valueType = ValueType.Factor;

        health = 1.5f;
        manaCost = 0;
    }

}
