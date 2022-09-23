using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModificatorsManager : MonoBehaviour
{
    public static ModificatorsManager Instance { get; private set; }

    public List<ModificatorBase> modificatorBases;

    private void Awake()
    {
        if (Instance != null) Instance = this;
        print("test1111111111");
        DontDestroyOnLoad(gameObject);
    }



}
