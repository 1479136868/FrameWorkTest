using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// 开始状态
/// </summary>
public class StartState : ISceneState
{
    public StartState(SceneStateController stateController) : base(stateController)
    {
        this.StateName = "StartScene";
    }

    public override void StateBegin()
    {
        /*********可读取配置表*********/

        ConfigManager.GetInstance();


    }

    /// <summary>
    ///  更新
    /// </summary>
    public override void StateUpdate()
    {
        m_Controller.SetState("MainMenuScene");
    }

}
