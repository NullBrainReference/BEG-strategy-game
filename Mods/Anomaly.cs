using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anomaly : ModificatorBase
{
    public Anomaly()
    {
    }
    public override Sprite GetImage()
    {

        var sprite = Resources.Load<Sprite>("Anomaly");
        return sprite;
    }

}
