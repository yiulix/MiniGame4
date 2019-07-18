using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowchartMangerBattle : MonoBehaviour
{
    public Fungus.Flowchart flowchart;
    public BattleScene battle;
    string[] toDialog;
    void Start()
    {
        battle.BattleState = 0;
    }

   void SetbattleValue()
    {
        toDialog=battle.OneTurn();
        flowchart.SetStringVariable("give", toDialog[0]);
        flowchart.SetStringVariable("accept", toDialog[1]);
        flowchart.SetStringVariable("damage", toDialog[2]);
        flowchart.SetIntegerVariable("battlestate", battle.BattleState);

    }
}
