using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public static class UITool
{
    private static GameObject m_CanvasObj = null;

    public static GameObject CanvasObj
    {
        get
        {
            if (m_CanvasObj == null)
                m_CanvasObj = GameObject.Find  ("UIRoot");
            return m_CanvasObj;
        } 
    }


    /// <summary>
    /// 获取UI组件
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="Container"></param>
    /// <param name="UIName"></param>
    /// <returns></returns>
    public static T GetUIComponent<T>(GameObject Container, string UIName) where T : UnityEngine.Component
    {
        // 找出子物件 
        GameObject ChildGameObject = UnityTool.FindChildGameObject(Container, UIName);
        if (ChildGameObject == null)
            return null;

        T tempObj = ChildGameObject.GetComponent<T>();
        if (tempObj == null)
        {
            Debug.LogWarning("元件[" + UIName + "]不是[" + typeof(T) + "]");
            return null;
        }
        return tempObj;
    }

    /// <summary>
    /// 获取UI组件
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="UIName"></param>
    /// <returns></returns>
    public static T GetUIComponent<T>(string UIName) where T : UnityEngine.Component
    {
        //                      canvas下     ui名字
        return GetUIComponent<T>(CanvasObj, UIName);
    }


    /// <summary>
    /// 释放
    /// </summary>
    public static void ReleaseCanvas()
    {
        m_CanvasObj = null;
    }
}
