using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// 游戏事件系统
/// 当要注册事件时，先要建一个主题脚本Subject         继承IGameEventSubject
/// 一个主题脚本可以对应N个观察者脚本Observer         继承IGameEventObserver
/// </summary>
public class GameEventSystem : IGameSystem
{
    /// <summary>
    /// 事件库
    /// 一个事件对应一个库，库内有不止一个观察者监听
    /// </summary>
    private Dictionary<ENUM_GameEvent, IGameEventSubject> m_GameEvents = new Dictionary<ENUM_GameEvent, IGameEventSubject>();

    public GameEventSystem(IGameManager GM) : base(GM)
    {
        Initialize();
    }

    /// <summary>
    /// 释放
    /// </summary>
    public override void Release()
    {
        m_GameEvents.Clear();
    }

    /// <summary>
    /// 给某一个主题注册观察者
    /// </summary>
    /// <param name="emGameEvnet"></param>
    /// <param name="Observer"></param>
    public void RegisterObserver(ENUM_GameEvent emGameEvnet, IGameEventObserver Observer)
    {
        IGameEventSubject Subject = GetGameEventSubject(emGameEvnet);
        //当事件主题不为空，注册进去
        if (Subject != null)
        {
            Subject.Attach(Observer);
            Observer.SetSubject(Subject);
        }
    }


    /// <summary>
    /// 通知主题中的观察者
    /// </summary>
    /// <param name="emGameEvnet"></param>
    /// <param name="Param"></param>
    public void NotifySubject(ENUM_GameEvent emGameEvnet, System.Object Param)
    {
        if (m_GameEvents.ContainsKey(emGameEvnet))
            //子类中会有派发           在这里我们只设置参数
            m_GameEvents[emGameEvnet].SetParam( Param);

    }

    /// <summary>
    /// 获取游戏事件的主题
    /// </summary>
    /// <param name="emGameEvnet"></param>
    /// <returns></returns>
    private IGameEventSubject GetGameEventSubject(ENUM_GameEvent emGameEvnet)
    {
        // 判断库里是否存在这个监听
        if (m_GameEvents.ContainsKey(emGameEvnet))
            return m_GameEvents[emGameEvnet];

        IGameEventSubject pSujbect = null;
        switch (emGameEvnet)
        {
            /*************根据对应的枚举生成不同的子类**************/
            case ENUM_GameEvent.Null:

                break;
            default:
                Debug.LogError("无对应子类模块关联");
                return null;
        }

        m_GameEvents.Add(emGameEvnet, pSujbect);
        return pSujbect;
    }
}
