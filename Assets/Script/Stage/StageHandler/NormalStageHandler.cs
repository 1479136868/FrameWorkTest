using UnityEngine;
using System.Collections;

/// <summary>
/// 一般关卡的响应
/// </summary>
public class NormalStageHandler : IStageHandler 
{

	public NormalStageHandler(IStageScore StateScore, IStageData StageData )
	{
		m_StageScore  = StateScore;
		m_StatgeData  = StageData;
	}
	
	public override void Update()
	{
		m_StatgeData.Update();
	}

	public override void Reset()
	{
		m_StatgeData.Reset();
	}

    public override bool IsFinished()
    {
		return m_StatgeData.IsFinished();
	}
     
	/// <summary>
	/// 检查关卡状态
	/// </summary>
	/// <returns></returns>
    public override IStageHandler CheckStage()
    {
		if (m_StageScore.CheckScore() == false)
			return this;
		
		//最后一个了
		if (m_NextHandler == null)
			return this;

		//	返回下一个
		return m_NextHandler.CheckStage();
	}
}
