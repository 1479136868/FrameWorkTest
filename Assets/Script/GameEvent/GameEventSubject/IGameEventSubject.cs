using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// 游戏事件主题
/// </summary>
public class IGameEventSubject 
{
	/// <summary>
	/// 观察者列表
	/// </summary>
	private List<IGameEventObserver> m_Observers = new List<IGameEventObserver>(); 

	/// <summary>
	/// 参数
	/// </summary>
	private System.Object m_Param = null;	 

	/// <summary>
	/// 添加
	/// </summary>
	/// <param name="theObserver"></param>
	public void Attach(IGameEventObserver theObserver)
	{
		m_Observers.Add( theObserver );
	}

	/// <summary>
	/// 移除
	/// </summary>
	/// <param name="theObserver"></param>
	public void Detach(IGameEventObserver theObserver)
	{
		m_Observers.Remove( theObserver );
	}

	/// <summary>
	///  通知
	/// </summary>
	public void Notify()
	{
		foreach( IGameEventObserver theObserver  in m_Observers)
			theObserver.Update();
	}

	/// <summary>
	/// 设置参数
	/// </summary>
	/// <param name="Param"></param>
	public virtual void SetParam( System.Object Param )
	{
		m_Param = Param;
	}
}
