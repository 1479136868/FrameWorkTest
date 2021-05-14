using UnityEngine;
using System.Collections;

/// <summary>
/// 关卡信息父类
/// </summary>
public abstract class IStageData
{
	public abstract void Update();
	public abstract	bool IsFinished();
	public abstract	void Reset();
}
