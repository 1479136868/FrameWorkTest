using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateOrChooseRoleState : ISceneState
{ 

    public CreateOrChooseRoleState(SceneStateController stateController) : base(stateController)
    {
        this.StateName = "CreateOrChooseRoleScene";
    }
    /// <summary>
    /// 开始
    /// </summary>
    public override void StateBegin()
    {
        CreateOrChooseRoleManager.Instance.Initinal();
    }

    /// <summary>
    /// 更新
    /// </summary>
    public override void StateUpdate()
    {
        CreateOrChooseRoleManager.Instance.Update();

        if (CreateOrChooseRoleManager.Instance.isSelect)
        {
            m_Controller.SetState("MainScene");
        }


    }

    /// <summary>
    /// 结束
    /// </summary>
    public override void StateEnd()
    {
        CreateOrChooseRoleManager.Instance.Release();
    }

}
