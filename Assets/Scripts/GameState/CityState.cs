using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityState : GameState
{
    protected override void OnLoadComplete(params object[] args)
    {
     
    }

    protected override void OnStart()
    {
        UIManager.Instance.ShowUIPanel("MainPanel");
        //显示角色
        //初始化背包
        //初始化商城
        //ToDo
    }

    protected override void OnStop()
    {
        //释放掉背包资源
        //释放掉商城资源、、、、、、、
    }
}
