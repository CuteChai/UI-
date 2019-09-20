using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginState : GameState
{
  
    protected override void OnLoadComplete(params object[] args)
    {
       
    }

    protected override void OnStart()
    {
        UIManager.Instance.ShowUIPanel("LoginPanel");//显示登陆界面

        EventManager.Instance.BindDing((int)LoginPanelEventID.loginBtnClickEvent, ()=>{ GameStateManager.Instance.SetGameState("CityState"); } );


    }

    protected override void OnStop()
    {
        
    }
}
