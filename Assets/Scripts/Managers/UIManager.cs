using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System;

 class UIManager : ManagerBase {

    private static UIManager instance;
    private Transform canvas;

    public static UIManager Instance
    {
        get
        {
            if (instance==null)
            {
                instance = FindObjectOfType<UIManager>();
            }
            return instance;
        }

    }


    public Dictionary<string, UIPanelBase> uiPool=new Dictionary<string, UIPanelBase>();//所有加载过的UIPanel的缓冲池

    public UIPanelBase currentPanel;//当前在显示的UI界面


    public void ShowUIPanel(string panelName) {

        //如果要显示的页面已经加载过
        if (uiPool.ContainsKey(panelName))
        {
      
            if (currentPanel==null)//如果当前没有界面在显示
            {
                currentPanel = uiPool[panelName];
                currentPanel.Show();
            }
           else if (currentPanel.name!= panelName)      //如果不是当前界面
            {
                //隐藏当前界面
                currentPanel.Hide();
                currentPanel = uiPool[panelName];
                currentPanel.Show();
            }
        }
        else//如果没有加载过
        {
           
            //通过C#反射利用字符串去获取当前UI界面的控制组件的类型
            System.Type t = Assembly.GetExecutingAssembly().GetType(panelName);


            GameObject go = ResourcesManager.Instance.LoadPrefab(panelName);//获取Panel预制体


            //实例化
            go = Instantiate<GameObject>(go, canvas);


            //添加Panel的脚本
            UIPanelBase panel= go.AddComponent(t) as UIPanelBase;

            go.name = panelName;

            //加入池中
            uiPool.Add(panelName, panel);




            //如果当前有UI界面
            if (currentPanel!=null)
            {
                //更换当前页面
                currentPanel.Hide();
                currentPanel = panel;
                currentPanel.Show();
            }
            else
            {
                //没有则直接显示
                currentPanel = panel;
                currentPanel.Show();
            }

        }

    }

    protected override void OnInit()
    {
        canvas = GameObject.Find("Canvas").transform;
    }
}
