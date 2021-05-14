using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// 角色的AI(AI的管理)
/// 包含AI状态
/// </summary>
public abstract class ICharacterAI 
{
	protected ICharacter m_Character = null;

	/// <summary>
	/// 攻击范围
	/// </summary>
	protected float		m_AttackRange = 3;

	/// <summary>
	/// AI状态
	/// </summary>
	protected IAIState  m_AIState = null;

	/// <summary>
	/// 攻击间隔
	/// </summary>
	protected const float ATTACK_COOLD_DOWN = 1f; 
	protected float m_CoolDown = ATTACK_COOLD_DOWN;

	public ICharacterAI( ICharacter Character)
	{
        m_Character = Character;
    }

	/// <summary>
	/// 更改当前状态
	/// </summary>
	/// <param name="NewAIState">新的状态</param>
	public virtual void ChangeAIState( IAIState NewAIState)
	{
		m_AIState = NewAIState;
		m_AIState.SetCharacterAI( this );
	}

	/// <summary>
	/// 攻击
	/// </summary>
	/// <param name="Target"></param>
	public virtual void Attack( ICharacter Target )
	{
		// 时间间隔到了，攻击
		m_CoolDown -= Time.deltaTime;
		if( m_CoolDown >0)
			return ;
		m_CoolDown = ATTACK_COOLD_DOWN;

		m_Character.Attack( Target );
	}

	/// <summary>
	/// 检测是否在攻击范围内
	/// </summary>
	/// <param name="Target"></param>
	/// <returns></returns>
	public bool TargetInAttackRange( ICharacter Target )
	{
		float dist = Vector3.Distance( m_Character.GetPosition() , 
		                               Target.GetPosition() );
		return ( dist <= m_AttackRange );
	}

	/// <summary>
	/// 获取当前的位置
	/// </summary>
	/// <returns></returns>
	public Vector3 GetPosition()
	{
		return m_Character.GetGameObject().transform.position;
	}

	/// <summary>
	/// 定点移动
	/// </summary>
	/// <param name="Position"></param>
	public void MoveTo( Vector3 Position )
	{
		m_Character.MoveTo( Position );
	}

	/// <summary>
	/// 停止移动
	/// </summary>
	public void StopMove()
	{
		m_Character.StopMove();
	}

	/// <summary>
	/// 设置死亡状态
	/// </summary>
	public void Killed()
	{
		m_Character.Killed();
	}

	/// <summary>
	/// 检测是否死亡
	/// </summary>
	/// <returns></returns>
	public bool IsKilled()
	{
		return m_Character.IsKilled(); 
	}

	/// <summary>
	/// 移除目标
	/// </summary>
	/// <param name="Target"></param>
	public void RemoveAITarget( ICharacter Target ) 
	{
		m_AIState.RemoveTarget( Target);  
	}

	/// <summary>
	///  更新AI
	/// </summary>
	/// <param name="Targets"></param>
	public void Update( ICharacter  Targets)
	{
		m_AIState.Update( Targets );
	} 


}
