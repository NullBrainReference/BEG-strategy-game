using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IModificator
{
    public float Value(object obj);
    public bool ForUnit(object obj);
    public Action Modification { set; get; }
}
