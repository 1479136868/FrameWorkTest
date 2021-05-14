using UnityEngine;
using System.Collections;

/// <summary>
/// 关卡的响应
/// 应用了责任链模式
/// </summary>
public abstract class IStageHandler
{
	/// <summary>
	/// 下一关
	/// </summary>
	protected IStageHandler m_NextHandler = null; 

	/// <summary>
	/// 关卡数据
	/// </summary>
	protected IStageData	m_StatgeData  = null;

	/// <summary>
	/// 关卡分数
	/// </summary>
	protected IStageScore   m_StageScore  = null; 

	/// <summary>
	/// 设置下一个关卡
	/// </summary>
	/// <param name="NextHandler"></param>
	/// <returns></returns>
	public IStageHandler SetNextHandler(IStageHandler NextHandler)
	{
		m_NextHandler = NextHandler;
		return m_NextHandler;
	}

	/// <summary>
	/// 检查
	/// </summary>
	/// <returns></returns>
	public abstract IStageHandler CheckStage();

	public abstract void Update();

	public abstract void Reset();

	public abstract bool IsFinished(); 
}
