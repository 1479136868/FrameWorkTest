using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// 怪物AI
/// </summary>
public class EnemyAI : ICharacterAI 
{
	private static StageSystem	m_StageSystem = null;
	private Vector3 m_AttackPosition = Vector3.zero;

	public static void SetStageSystem(StageSystem StageSystem)
	{
		m_StageSystem = StageSystem;
	}

	public EnemyAI(ICharacter Character ):base(Character)
	{  
		ChangeAIState(new IdleAIState());
	}


	public override void ChangeAIState( IAIState NewAIState)
	{
		base.ChangeAIState( NewAIState);


		NewAIState.SetAttackPosition(m_AttackPosition);
	}
	 
}
