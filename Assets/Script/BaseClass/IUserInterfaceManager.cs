using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IUserInterfaceManager : Singleton<IUserInterfaceManager>
{
    private Transform UI_Root = null;

    private Transform Normal;

    private Transform Fixed;

    private Transform PopUp;

    private Dictionary<Type, IUserInterfaceConfig> uiCache = null;

    private Dictionary<Type, IUserInterface> uiShowCache = null;


    public IUserInterfaceManager()
    {
        UI_Root = UnityTool.FindGameObject("UIRoot").transform;

        Normal = UnityTool.FindChildGameObject(UI_Root.gameObject, "Normal").transform;

        Fixed = UnityTool.FindChildGameObject(UI_Root.gameObject, "Fixed").transform;

        PopUp = UnityTool.FindChildGameObject(UI_Root.gameObject, "PopUp").transform;

        uiCache = new Dictionary<Type, IUserInterfaceConfig>();

        uiShowCache = new Dictionary<Type, IUserInterface>();
    }

    public void Update()
    {
        foreach (var item in uiShowCache)
        {
            item.Value.Update();
        }
    }

    public void OpenUI(Type name)
    {
        IUserInterfaceConfig temp = LoadUIbase(name);
        switch (temp.layer)
        {
            case ENUM_UILayer.Normal:
                temp.View.SetParent(Normal, false);
                break;
            case ENUM_UILayer.Fixed:
                temp.View.SetParent(Fixed, false);
                break;
            case ENUM_UILayer.PopUp:
                temp.View.SetParent(PopUp, false);
                break;
            default:
                break;
        }
        //通过分类的这里去 真正的打开界面

        temp.Model.OnEnable();
        temp.View.Show();
        temp.Ctrl.OnEnable();

        if (!uiShowCache.ContainsKey(name))
        {
            uiShowCache.Add(name, temp.View);
        }

    }

    public void CloseUI(Type name)
    {
        if (uiCache.ContainsKey(name))
        {
            uiCache[name].Ctrl.OnDisable();
            uiCache[name].Model.OnDisable();
            uiCache[name].View.Hide();
            if (uiShowCache.ContainsKey(name))
            {
                uiShowCache.Remove(name);
            }
        }
    }

    //加载的方式
    private IUserInterfaceConfig LoadUIbase(Type name)
    {
        IUserInterfaceConfig uiConfig;
        if (uiCache.TryGetValue(name, out uiConfig))
        {
            uiConfig = uiCache[name];
        }
        else
        {
            //动态创建配置的实例
            uiConfig = Activator.CreateInstance(name) as IUserInterfaceConfig;

            if (uiConfig == null)
            {
                Debug.LogError("此类型不对劲！！！");
            }
            else
            {
                //根据配置的路径加载面板
                GameObject res = Resources.Load<GameObject>("UIPanel/" + uiConfig.prefab_Path);

                if (res == null)
                {
                    Debug.LogError("加载路径错误！");
                }
                else
                {
                    //我们先不认父级 因为又一个渲染优先级的问题？ TODO
                    GameObject clone = GameObject.Instantiate(res);
                    clone.name = uiConfig.prefab_Path;

                    uiCache.Add(name, uiConfig);

                    uiConfig.Model.Initialize();
                    
                    //V层初始化是根据路径找UIRoot的
                    uiConfig.View.Initialize(uiConfig.prefab_Path);
                    
                    uiConfig.Ctrl.Initialize();

                }
            }

        }
        return uiConfig;
    }

    public bool IsVisible(Type t)
    {
        if (uiCache.ContainsKey(t))
        {
            return uiCache[t].View.IsVisible();
        }

        Debug.LogError(t.ToString() + "不在缓存池中！！！");

        return false;
    }
}
