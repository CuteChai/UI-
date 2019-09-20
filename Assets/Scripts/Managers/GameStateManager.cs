using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System;

class SceneData {

    public string gameState;
    public int secenID;

}
 class GameStateManager : ManagerBase
{
    static GameStateManager _instance;
    public static GameStateManager Instance {
        get {

            if (_instance==null)
            {
                _instance = FindObjectOfType<GameStateManager>();
            }
            return _instance;
        }
    }


    public GameState currentSta = null;//当前游戏状态
    public Dictionary<string, GameState> m_GameStaMap = new Dictionary<string, GameState>();//所有已加载过的游戏状态的缓冲池


    public void SetGameState(string name) {
        if (m_GameStaMap.ContainsKey(name)) //有没有加过这个状态
        {
            if (currentSta==null||currentSta!= m_GameStaMap[name])//当前有没有游戏状态或者是不是你传入的状态
            {
                currentSta.Stop();//停止当前状态
                currentSta = m_GameStaMap[name];
                currentSta.Start();//开始新的状态
            }


        }
        else
        {
            //通过反射机制，使用字符串创建类对象
            GameState gameState = Assembly.GetExecutingAssembly().CreateInstance(name) as GameState;
            //SecenManager.instance.LoadScene(scenedata.id)

            if (gameState==null)
            {
                Debug.LogError("gameState is error");
                return;
            }


            if (currentSta!=null)
            {
                currentSta.Stop();
                
            }

            currentSta = gameState;
            currentSta.Start();
        }
        
    }

    protected override void OnInit()
    {
       
    }
}
