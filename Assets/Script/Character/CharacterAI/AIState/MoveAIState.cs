using UnityEngine;
using System.Collections.Generic;


public class MoveAIState : IAIState
{
    private const float MOVE_CHECK_DIST = 1.5f;

    Vector3 m_AttackPosition = Vector3.zero;

    public MoveAIState()
    { }


    public override void SetAttackPosition(Vector3 AttackPosition)
    {
        m_AttackPosition = AttackPosition;
    }


    public override void Update(ICharacter Targets)
    {
        //没目标，换Idel
        if (Targets == null)
        {
            m_CharacterAI.ChangeAIState(new IdleAIState());
            return;
        }

        float dist = Vector3.Distance(m_AttackPosition, m_CharacterAI.GetPosition() + new Vector3(0, 2, 0));
        //距离小于停止距离，停下(换Idel),Idel里有去攻击的逻辑
        if (dist < MOVE_CHECK_DIST)
        {
            m_CharacterAI.ChangeAIState(new IdleAIState());

            //m_CharacterAI.Killed();
        }
        else
        {
            m_CharacterAI.MoveTo(m_AttackPosition);
        }

    }

}
