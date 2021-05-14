using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// 主界面状态
/// </summary>
public class MainMenuState : ISceneState
{

	public MainMenuState(SceneStateController stateController ):base(stateController)
	{
		this.StateName = "MainMenuScene";
	}


	/// <summary>
	/// 开始
	/// </summary>
	public override void StateBegin()
	{
		IUserInterfaceManager.GetInstance().OpenUI(typeof(StartGameUIConfig));
	}
			
    public override void StateEnd()
    { 
        base.StateEnd();
    }
}
