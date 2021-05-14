using UnityEngine;
using System.Collections;

/// <summary>
/// 游戏子系统的父类
/// </summary>
public abstract class IGameSystem
{
	protected IGameManager m_GM = null;
	public IGameSystem(IGameManager GM )
	{
		m_GM = GM;
	}

	public virtual void Initialize(){}
	public virtual void Release(){}
	public virtual void Update(){}

}
