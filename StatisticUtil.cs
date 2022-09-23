using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatisticUtil : MonoBehaviour
{
    public enum Action {Empty, Atack, Select, Move, Use }
    public  int playerNo = -1;
    public Action action;
    public ModController modController;
    public CellController curCell;

    public static StatisticUtil Instace { get; private set; }

    private void Awake()
    {
        Instace = this;
    }

    public void SetAction(Action _action)
    {
        action = _action;
    }

    public void SetPlayerNo(int _playerNo)
    {
        playerNo = _playerNo;
    }

}
