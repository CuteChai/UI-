using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginPanel : UIPanelBase
{
    private Button loginBtn;

    protected override void OnDispose()
    {
        
    }

    protected override void OnHide()
    {

    }

    protected override void OnInit()
    {
        loginBtn = transform.Find("Button").GetComponent<Button>();//找到登录按钮
        EventManager.Instance.Register((int)LoginPanelEventID.loginBtnClickEvent,loginBtn.onClick);//把登陆按钮的点击事件注册到事件中心


    

    }
    protected override void OnShow()
    {
        
    }
}
