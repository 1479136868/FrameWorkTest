using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// AI状态基类
/// </summary>
public abstract class IAIState
{
    /// <summary>
    /// 角色
    /// </summary>
    protected ICharacterAI m_CharacterAI = null;

    public IAIState()
    { }

    /// <summary>
    /// 设置角色
    /// </summary>
    /// <param name="CharacterAI"></param>
    public void SetCharacterAI(ICharacterAI CharacterAI)
    {
        m_CharacterAI = CharacterAI;
    }

    /// <summary>
    /// 设置目标位置
    /// </summary>
    /// <param name="AttackPosition"></param>
    public virtual void SetAttackPosition(Vector3 AttackPosition)
    { }

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="Targets"></param>
    public abstract void Update(ICharacter Targets);

    /// <summary>
    /// 移除目标
    /// </summary>
    /// <param name="Target"></param>
    public virtual void RemoveTarget(ICharacter Target)
    { }

}
