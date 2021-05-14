using UnityEngine;
using System.Collections;

/// <summary>
/// 场景状态基类
/// </summary>
public class ISceneState
{
	/// <summary>
	/// 状态名称
	/// </summary>
	private string m_StateName = "ISceneState";

	public string StateName
	{
		get{ return m_StateName; }
		set{ m_StateName = value; }
	}

	/// <summary>
	/// 场景控制者
	/// </summary>
	protected SceneStateController m_Controller = null;
		
	public ISceneState(SceneStateController Controller)
	{ 
		m_Controller = Controller; 
	}

	/// <summary>
	/// 开始状态
	/// </summary>
	public virtual void StateBegin()
	{}

	/// <summary>
	/// 结束状态
	/// </summary>
	public virtual void StateEnd()
	{}

	/// <summary>
	/// 更新
	/// </summary>
	public virtual void StateUpdate()
	{}

	public override string ToString ()
	{
		return string.Format ("当前状态：+", StateName);
	}


}
