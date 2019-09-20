using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleState : GameState
{
    protected override void OnLoadComplete(params object[] args)
    {
       
    }

    protected override void OnStart()
    {
        UIManager.Instance.ShowUIPanel("BattlePanel");



    }

    protected override void OnStop()
    {
        
    }
}
