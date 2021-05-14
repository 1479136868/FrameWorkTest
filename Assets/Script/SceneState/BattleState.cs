using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// 战斗状态
/// </summary>
public class BattleState : ISceneState
{ 

	public BattleState(SceneStateController stateController) :base(  stateController)
	{
		this.StateName = "BattleScene";
	}

	/// <summary>
	/// 开始
	/// </summary>
	public override void StateBegin()
	{
		BattleManager.Instance.Initinal();
	}

	/// <summary>
	/// 结束
	/// </summary>
	public override void StateEnd()
	{
		BattleManager.Instance.Release();
	}

	/// <summary>
	/// 更新
	/// </summary>
	public override void StateUpdate()
	{
		//每帧调用游戏逻辑
		BattleManager.Instance.Update();
		
		//渲染由引擎负责

		//判断是否游戏结束
		if (BattleManager.Instance.ThisGameIsOver())
			m_Controller.SetState( "MainMenuScene" );
	}
}
