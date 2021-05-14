using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 消息中心管理类
/// </summary>
public class MessManager :Singleton<MessManager>
{
    Dictionary<string, Action<object>> mesdic = new Dictionary<string, Action<object>>();

    //监听消息
    public void RegisterMessage(string name,Action<object> action)
    {
        if (mesdic.ContainsKey(name))
        {
            mesdic[name] += action;
        }
        else
        {
            mesdic.Add(name, action);
        }
    }

    /// <summary>
    ///发送消息
    /// </summary>
    public void SendMes(string name,params object[] obj)
    {
        if (mesdic.ContainsKey(name))
        {
            mesdic[name](obj);
        }
       
    }

    /// <summary>
    /// 移除消息
    /// </summary>
    /// <param name="name"></param>
    /// <param name="action"></param>
   public void Removemes(string name,Action<object> action)
    {
        if (mesdic.ContainsKey(name))
        {
            mesdic[name] -= action;
            if (mesdic[name] == null)
            {
                mesdic.Remove(name);
            }
        }
    }

}
