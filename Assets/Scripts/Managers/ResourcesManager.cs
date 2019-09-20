using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class ResourcesManager : ManagerBase
{

    public static ResourcesManager _instance;

    public static ResourcesManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<ResourcesManager>();
            }
            return _instance;
        }

    }


    //加载预制体
    public GameObject LoadPrefab(string name) {

        string path = "Prefabs" + "/" + name;


        GameObject go = Resources.Load<GameObject>(path);
        if (go==null)
        {
            Debug.LogError("加载失败，资源路径:" + path);

        }

        return go;

    }

    //加载图
    public Sprite LoadSprite(string path) {

        Sprite sprite = Resources.Load<Sprite>(path);
        if (sprite==null)
        {
            Debug.LogError("加载失败，资源路径：" + path);
        }
        return sprite;

    }
    //加载图集
    public Sprite[] LoadSprites(string name)
    {
        string path = name;
        Sprite[] sprites = Resources.LoadAll<Sprite>(path);
        if (sprites.Length==0)
        {
            Debug.LogError("加载失败，资源路径：" + path);
        }
        return sprites;

        

    }

    protected override void OnInit()
    {
        
    }
}
