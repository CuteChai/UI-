using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrap :MonoBehaviour {

    //awake优先于start

    //OnEable游戏物体激活的时候执行一次    
    //start游戏开始的第一帧执行一次

    //fixedupdate 每固定时间执行一次 在Time里面可以设置刷新频率

    //update每一帧执行一次，每一帧的执行时间，取决于这一帧执行完需要多久
    //lateupdate比update晚，每一帧执行一次，每一帧的执行时间，取决于这一帧执行完需要多久

    //OnDisable游戏物体失活的时候执行一次

    //OnDestroy游戏物体销毁的时候执行一次

    //OnCollisionEnter
    //OnCollisionStay;
    //OnCollsionExit

    //OnTriggerEnter
    //OnTriggerStay
    //OnTriggerExit







    // Use this for initialization
    void Start () {
        AddManagers();
        InitAllManager();
        //UIManager.Instance.ShowUIPanel("LoginPanel");

        GameStateManager.Instance.SetGameState("LoginState");
    }

    void AddManagers() {

        gameObject.AddComponent<UIManager>();
        gameObject.AddComponent<ResourcesManager>();
        gameObject.AddComponent<GameStateManager>();
        gameObject.AddComponent<EventManager>();



    }

    void InitAllManager() {

        UIManager.Instance.Init();
    }

}
