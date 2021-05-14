using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// 待机状态
/// </summary>
public class IdleAIState : IAIState
{
    private bool m_bSetAttackPosition = false;

    public IdleAIState()
    { }

    /// <summary>
    /// 设置攻击目标
    /// </summary>
    /// <param name="AttackPosition"></param>
    public override void SetAttackPosition(Vector3 AttackPosition)
    {
        m_bSetAttackPosition = true;
    }

    float MinDist = 999f;

    public override void Update(ICharacter Targets)
    {
        //没玩家
        if (Targets == null)
        {
            //设置了攻击目标，则更换移动状态
            if (m_bSetAttackPosition)
                m_CharacterAI.ChangeAIState(new MoveAIState());
            return;
        } 

        //玩家死亡
        if (Targets.IsKilled())
            return;

        
        //在攻击范围内，攻击
        if (m_CharacterAI.TargetInAttackRange(Targets))
            m_CharacterAI.ChangeAIState(new AttackAIState(Targets));
        else
            //不在攻击范围内，追击
            m_CharacterAI.ChangeAIState(new ChaseAIState(Targets));
    }
}
