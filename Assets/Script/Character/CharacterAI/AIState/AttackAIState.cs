using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// 攻击AI
/// </summary>
public class AttackAIState : IAIState 
{

	private ICharacter m_AttackTarget = null; 

	public AttackAIState( ICharacter AttackTarget )
	{
		m_AttackTarget = AttackTarget;
	}			
	 
	public override void Update( ICharacter Targets )
	{
		//没有目标换成Idel
		if(m_AttackTarget == null || m_AttackTarget.IsKilled() || Targets == null  )
		{
			m_CharacterAI.ChangeAIState( new IdleAIState()); 
			return ;
		}

		//检测自身位置和敌人位置，达到一定距离换为追击
		if(!m_CharacterAI.TargetInAttackRange( m_AttackTarget)  )
		{

			m_CharacterAI.ChangeAIState( new ChaseAIState(m_AttackTarget)); 
			return ;
		}

		// 攻击
		m_CharacterAI.Attack( m_AttackTarget );
	}

	// 移除目标
	public override void RemoveTarget(ICharacter Target)
	{
		if( m_AttackTarget.GetGameObject().name == Target.GetGameObject().name )
			m_AttackTarget = null;
	}

}
