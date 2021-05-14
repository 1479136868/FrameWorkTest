using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainState : ISceneState
{
	public MainState(SceneStateController stateController) : base(stateController)
	{
		this.StateName = "MainScene";
	}

	/// <summary>
	/// 开始
	/// </summary>
	public override void StateBegin()
	{
		MainManager.Instance.Initinal();
	}

	/// <summary>
	/// 结束
	/// </summary>
	public override void StateEnd()
	{
		MainManager.Instance.Release();
	}

	/// <summary>
	/// 更新
	/// </summary>
	public override void StateUpdate()
	{
		//每帧调用游戏逻辑
		 MainManager.Instance.Update();

        //渲染由引擎负责

        ////判断是否游戏结束
        if (MainManager.Instance.info!=null)
			m_Controller.SetState("BattleScene");
    }
}
