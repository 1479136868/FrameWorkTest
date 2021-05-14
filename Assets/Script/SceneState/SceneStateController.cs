using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System;

/// <summary>
/// 场景状态拥有者，保持当前游戏场景状态，并作为与GameLoop类互动的接口
/// 除此之外，也是执行“Unity3D场景转换”的地方
/// </summary>
public class SceneStateController
{
    private Dictionary<string, ISceneState> caChe = null;

    private ISceneState m_State;
    private string m_StateName = string.Empty;

    private bool m_bRunBegin = false;

    public SceneStateController()
    {
        caChe = new Dictionary<string, ISceneState>();
    }

    /// <summary>
    /// 添加状态的缓存
    /// </summary>
    /// <param name="State">对应状态的对象</param>
    public void AddSceneState(ISceneState State)
    {
        if (State == null)
        {
            Debug.LogError("新增的状态为空！！！");
            return;
        }
        if (caChe.ContainsKey(State.StateName))
        {
            Debug.LogError("状态已存在，无法重复添加！！！");
            return;
        }
        caChe.Add(State.StateName, State);
    }

    /// <summary>
    /// 删除状态
    /// </summary>
    /// <param name="StateName">状态名字</param>
    public void DeleteState(string StateName)
    {

        if (string.IsNullOrEmpty(StateName) || string.IsNullOrWhiteSpace(StateName))
        {
            Debug.LogError("空状态无法删除！！！");
            return;
        }
        if (!caChe.ContainsKey(StateName))
        {
            Debug.LogError("状态库不存在此状态！！！");
            return;
        }
        caChe.Remove(StateName);
    }

    /// <summary>
    /// 设置当前状态
    /// </summary>
    /// <param name="State"></param>
    /// <param name="LoadSceneName"></param>
    public void SetState(string LoadSceneName)
    {


        m_bRunBegin = false;

        //加载场景
        LoadScene(LoadSceneName);

        //清理上一个场景
        if (m_State != null)
            m_State.StateEnd();

        //改变当前状态
        if (caChe.ContainsKey(LoadSceneName))
        {
            m_State = caChe[LoadSceneName];
            return;
        }
        Debug.LogError("库内未存储此状态！！！" + LoadSceneName);
    }

    /// <summary>
    /// 加载场景
    /// </summary>
    /// <param name="LoadSceneName"></param>
    private void LoadScene(string LoadSceneName)
    {
        //|| LoadSceneName == "MainMenuScene"

        if (LoadSceneName == null || LoadSceneName.Length == 0 || LoadSceneName == "StartScene" )
            return;
        //走进度条
        SceneInfoManager.LoadingNextScene(LoadSceneName);
    }

    /// <summary>
    /// 状态更新
    /// </summary>
    public void StateUpdate()
    {
        // 是否在加载中
        if (SceneInfoManager.isLoadingLevel)
            return;

        // 通知新的State开始	(每一个换到一个新场景，之后就跑一次)
        if (m_State != null && m_bRunBegin == false)
        {
            m_State.StateBegin();
            m_bRunBegin = true;
        }

        if (m_State != null)
            m_State.StateUpdate();
    }
}
