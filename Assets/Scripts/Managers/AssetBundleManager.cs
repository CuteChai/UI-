using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//资源管理器
//负责管理所有资源的加载和卸载，获取
class AssetBundleManager : ManagerBase
{
    private static AssetBundleManager _instance;//单例
    private Dictionary<string, AssetBundle> ABPool;//ab包池
    private AssetBundleManifest maniFest;//ab包manifest文件对象

    public static AssetBundleManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<AssetBundleManager>();
            }
            return _instance;
        }

    }

    //初始化
    private void Awake()
    {
        ABPool = new Dictionary<string, AssetBundle>();
        maniFest = null;
    }




    //加载ab包
    public AssetBundle LoadAssetBundle(string abName)
    {

        //判断AB包池内是否已存在该包
        if (!ABPool.ContainsKey(abName) || ABPool[abName] == null)
        {


            //1.获取路径，创建依赖表
            string path = Setting.AssetBundlesSavePathName + Setting.AssetBundlesSavePathName;
            List<string> allnames = new List<string>();


            //2.判断路径ab主包是否存在
            if (!HardDisck.FileExists(HardDisck.GetWriteablePath(path)))
            {
                Debug.LogError("AB包总文件不存在！" + path);
                return null;
            }


            //3.判断manifest对象是否存在
            if (maniFest == null)
            {
                AssetBundle main = AssetBundle.LoadFromFile(HardDisck.GetWriteablePath(path));
                maniFest = main.LoadAsset<AssetBundleManifest>("AssetBundleManifest");


            }

            //4.添加依赖关系到表里
            allnames.Add(abName);
            string[] dependencies = maniFest.GetAllDependencies(abName);
            for (int i = 0; i < dependencies.Length; i++)
            {

                if (allnames.Contains(dependencies[i]))
                {

                    continue;
                }
                else
                {

                    allnames.Add(dependencies[i]);
                }
            }



            //5.加载前判断文件是否存在
            for (int i = 0; i < allnames.Count; i++)
            {

                string realpath = HardDisck.GetWriteablePath(Setting.AssetBundlesSavePathName + "/" + allnames[i] + ".ab");
                if (!HardDisck.FileExists(realpath))
                {
                    Debug.LogError(realpath + "文件路径出错或不存在！");
                    return null;
                }
                else
                {
                    AssetBundle bundle = AssetBundle.LoadFromFile(realpath);
                    if (bundle == null)
                    {
                        Debug.Log("加载ab文件失败" + realpath);
                       

                    }
                    else
                    {
                        ABPool[allnames[i]] = (bundle);
                        Debug.Log("成功加载ab文件" + realpath);
                        
                    }

                    return bundle;

                }
            }


            return null;

        }
        else
        {
            Debug.Log("已加载过" + abName);
            return ABPool[abName];

        }
    }




    public Sprite LoadSpriteAsset(string abName, string assetName) {
        if (!ABPool.ContainsKey(abName) || ABPool[abName] == null)
        {
            LoadAssetBundle(abName);
        }

       Sprite asset = ABPool[abName].LoadAsset<Sprite>(assetName);
        if (asset == null)
        {
            Debug.LogError(abName + "包的" + assetName + "加载失败！");
            return null;
        }
        return asset;

    }


    //加载资源
    public UnityEngine.Object LoadAsset(string abName, string assetName, System.Type type)
    {

            if (!ABPool.ContainsKey(abName) || ABPool[abName] == null)
            {
                LoadAssetBundle(abName);
            }

           UnityEngine.Object asset = ABPool[abName].LoadAsset(assetName, type) ;
            if (asset == null)
            {
                Debug.LogError(abName + "包的" + assetName + "加载失败！");
                return null;
            }
        return asset;
    }

    protected override void OnInit()
    {
       
    }
}
