using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

 class PlayerInputManager : ManagerBase
{
    public static PlayerInputManager _instance;
    UnityEvent leftPressEvent = new UnityEvent();
    UnityEvent leftUpEvent = new UnityEvent();
    UnityEvent rightPressedpEvent = new UnityEvent();
    UnityEvent CountEvent = new UnityEvent();

    public bool leftPressed;
    public bool rightPressed;

    private int count = 0;
    float currentTime = 0;
    float lastTime = 0;

    public int Count { get { return count; } }
    public static PlayerInputManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<PlayerInputManager>();
            }
            return _instance;
        }

    }


    public void RegisterInputEvent()
    {
        EventManager.Instance.Register((int)PlayInputEventID.rightPressedpEvent, rightPressedpEvent);
        EventManager.Instance.Register((int)PlayInputEventID.CountEvent, CountEvent);
    }


    private void Update()
    {    
      

        if (Input.GetMouseButtonDown(0))
        {
        
            leftPressed = true;
            if (count==0)
            {
                lastTime = Time.realtimeSinceStartup;
            }
            count++;
            if (count==2)
            {
                currentTime = Time.realtimeSinceStartup;
                if (currentTime-lastTime<0.2f)
                {
                    lastTime = currentTime;
                    count = 0;
                    CountEvent.Invoke();
                }
                else
                {
                    lastTime = Time.realtimeSinceStartup;
                    count = 1;
                }
            }

        }


        if (Input.GetMouseButtonUp(0))
        {
            leftPressed = false;

        }

        if (Input.GetMouseButtonDown(1))
        {
          
            rightPressedpEvent.Invoke();
            rightPressed = true;
        }


    }

    protected override void OnInit()
    {
        
    }
}
