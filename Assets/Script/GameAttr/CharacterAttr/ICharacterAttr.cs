using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// 角色属性
/// </summary>
public abstract class ICharacterAttr
{
    /// <summary>
    /// 角色的享元的属性
    /// </summary>
    protected BaseAttr m_BaseAttr = null;

    /// <summary>
    /// 当前HP值
    /// </summary>
    protected int m_NowHP = 0;

    /// <summary>
    /// 数值计算策略
    /// </summary>
    protected IAttrStrategy m_AttrStrategy = null;

    public ICharacterAttr() { }

    /// <summary>
    /// 设置基本属性
    /// </summary>
    /// <param name="BaseAttr"></param>
    public void SetBaseAttr(BaseAttr BaseAttr)
    {
        m_BaseAttr = BaseAttr;

        //设置最初属性的时候，当前血量为最大血量
        //m_NowHP = BaseAttr.GetMaxHP();
    }

    /// <summary>
    /// 返回基本属性
    /// </summary>
    /// <returns></returns>
    public BaseAttr GetBaseAttr()
    {
        return m_BaseAttr;
    }

    /// <summary>
    /// 设置数值计算策略
    /// </summary>
    /// <param name="theAttrStrategy"></param>
    public void SetAttStrategy(IAttrStrategy theAttrStrategy)
    {
        m_AttrStrategy = theAttrStrategy;
    }

    /// <summary>
    /// 获取数值计算策略
    /// </summary>
    /// <returns></returns>
    public IAttrStrategy GetAttStrategy()
    {
        return m_AttrStrategy;
    }

    /// <summary>
    /// 计算伤害
    /// </summary>
    /// <param name="attacker"></param>
    public void CalDmgValue(ICharacter attacker)
    {

        int AtkValue = attacker.GetAtkValue();

        AtkValue -= m_AttrStrategy.GetDmgDescValue(this);

        m_NowHP -= AtkValue;
    }

    /// <summary>
    /// 计算出当前剩余血量
    /// </summary>
    /// <param name="attacker"></param>
    public void CalDmgValue(int attacker)
    {
        m_NowHP -= attacker;

        Debug.LogError("玩家："+ "m_NowHP"+ m_NowHP);

        
    }

    /// <summary>
    /// 获取当前HP
    /// </summary>
    /// <returns></returns>
    public int GetNowHP()
    {
        return m_NowHP;
    }

    /// <summary>
    /// 获取最大HP
    /// </summary>
    /// <returns></returns>
    public virtual int GetMaxHP()
    {
        return m_BaseAttr.GetMaxHP();
    }

    /// <summary>
    /// 获取移动速度
    /// </summary>
    /// <returns></returns>
    public virtual float GetMoveSpeed()
    {
        return m_BaseAttr.GetMoveSpeed();
    }

    /// <summary>
    /// 初始角色数值
    /// </summary>
    public virtual void InitAttr()
    {
        if (m_AttrStrategy != null)
        {
            m_AttrStrategy.InitAttr(this);
        }

        FullNowHP();
    }

    /// <summary>
    /// 加满血
    /// </summary>
    public void FullNowHP()
    {
        if (m_BaseAttr != null)
        {
            m_NowHP = GetMaxHP();
        }

    }
}
