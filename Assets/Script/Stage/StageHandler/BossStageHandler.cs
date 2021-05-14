using UnityEngine;
using System.Collections;

/// <summary>
/// Boss关卡响应，继承普通关卡
/// </summary>
public class BossStageHandler : NormalStageHandler 
{
	public BossStageHandler(IStageScore StateScore, IStageData StageData ):base(StateScore,StageData) 
	{}


}

