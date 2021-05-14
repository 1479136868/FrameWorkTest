using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// 追击
/// </summary>
public class ChaseAIState : IAIState
{
    private ICharacter m_ChaseTarget = null;

    private const float CHASE_CHECK_DIST = 0.5f;
    private Vector3 m_ChasePosition = Vector3.zero;


    public ChaseAIState(ICharacter ChaseTarget)
    {
        m_ChaseTarget = ChaseTarget;
    }

    // 更新
    public override void Update(ICharacter Targets)
    {
        // 沒有目标，换Idel
        if (m_ChaseTarget == null || m_ChaseTarget.IsKilled())
        {
            m_CharacterAI.ChangeAIState(new IdleAIState());
            return;
        }

        // 进入了范围，换成攻击
        if (m_CharacterAI.TargetInAttackRange(m_ChaseTarget))
        {
            m_CharacterAI.StopMove();   //可以不写
            m_CharacterAI.ChangeAIState(new AttackAIState(m_ChaseTarget));
            return;
        }


        float dist = Vector3.Distance(m_ChasePosition, m_CharacterAI.GetPosition() + new Vector3(0, 2, 0));

        if (dist < CHASE_CHECK_DIST )
            m_CharacterAI.ChangeAIState(new IdleAIState());
        else
        {

            m_ChasePosition = m_ChaseTarget.GetPosition() + new Vector3(0, 2, 0);
            m_CharacterAI.MoveTo(m_ChasePosition);

        }

    }

    /// <summary>
    /// 移除目标
    /// </summary>
    /// <param name="Target"></param>
    public override void RemoveTarget(ICharacter Target)
    {
        if (m_ChaseTarget.GetGameObject().name == Target.GetGameObject().name)
            m_ChaseTarget = null;
    }
}
