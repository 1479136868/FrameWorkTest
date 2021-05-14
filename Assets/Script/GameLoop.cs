using UnityEngine;
using System;
using System.Collections;
using UnityEditor;

/// <summary>
/// 游戏主循环
/// 包含了初始化游戏和定期调用更新操作
/// </summary>
public class GameLoop : MonoBehaviour
{
    SceneStateController m_SceneStateController = null;

    void Awake()
    {
        GameObject.DontDestroyOnLoad(this.gameObject);
        m_SceneStateController = new SceneStateController();
        AddState();
    }

    private void AddState()
    {
        m_SceneStateController.AddSceneState(new StartState(this.m_SceneStateController));
        m_SceneStateController.AddSceneState(new MainMenuState(this.m_SceneStateController));
        m_SceneStateController.AddSceneState(new BattleState(this.m_SceneStateController));
        m_SceneStateController.AddSceneState(new CreateOrChooseRoleState(this.m_SceneStateController));
        m_SceneStateController.AddSceneState(new MainState(this.m_SceneStateController));

    }

    private void Start()
    {
        //初始化咱的UI管理类
        IUserInterfaceManager.GetInstance();

        Tips.Instance.Hide();

        // 设置开始场景
        m_SceneStateController.SetState("StartScene");

        MessManager.GetInstance().RegisterMessage("SwitchState", SwitchState);
    }

    private void Update()
    {
        m_SceneStateController.StateUpdate();

        IUserInterfaceManager.GetInstance().Update();
    }

    private void SwitchState(object state)
    {
        object[] objs = (state as object[]);
        m_SceneStateController.SetState(objs[0] as string);
    }

}
