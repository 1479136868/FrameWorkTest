using UnityEngine;
using System.Collections;


// Enemy角色界面
public abstract class IEnemy : ICharacter
{
    /// <summary>
    /// 敌人类型
    /// </summary>
    protected ENUM_Enemy m_emEnemyType = ENUM_Enemy.Null;

    public IEnemy()
    { }

    /// <summary>
    /// 获取敌人类型
    /// </summary>
    /// <returns></returns>
    public ENUM_Enemy GetEnemyType()
    {
        return m_emEnemyType;
    }

    Animator _animator;

    /// <summary>
    /// 攻击
    /// </summary>
    /// <param name="Target"></param>
    public override void Attack(ICharacter Target)
    {
        _animator = GetGameObject().GetComponent<Animator>();
        if (_animator)
        {
            _animator.SetTrigger("Attack");

            Target .UnderAttack(this);

            Debug.Log(m_Attribute.GetAttStrategy().GetAtkPlusValue(m_Attribute).ToString());

        }
    }


    /// <summary>
    /// 被击
    /// </summary>
    /// <param name="Attacker"></param>
    public override void UnderAttack(ICharacter Attacker)
    {

        Debug.LogError(m_AssetName + "被" + Attacker.m_GameObject.name + "攻击了！！！" + Attacker.GetAttribute().GetAttStrategy().GetAtkPlusValue(m_Attribute));
        m_Attribute.CalDmgValue(Attacker.GetAttribute().GetAttStrategy().GetAtkPlusValue(m_Attribute));

        if (IsKilled())
        {
            Killed();

            CharacterSystem.Instance.RemoveEnemy(this );

        }
    }


    // 播放音效
    public abstract void DoPlayHitSound();

    // 播放特效
    public abstract void DoShowHitEffect();


}
