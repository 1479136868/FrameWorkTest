using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// Soldier角色界面
/// 玩家阵营，实现了攻击目标Attack()时，只需要调用父类的WeaponAttackTarget()方法
/// 就可以使用当前装备的武器攻击对手
/// </summary>
public abstract class ISoldier : ICharacter
{
    protected ENUM_Role m_emSoldier = ENUM_Role.Null;

    public ISoldier()
    {
    }

    public ENUM_Role GetSoldierType()
    {
        return m_emSoldier;
    }

    // 取得目前的角色值
    public SoldierAttr GetSoldierValue()
    {
        return m_Attribute as SoldierAttr;
    }

    public override void Attack(ICharacter Target)
    {

    }

    /// <summary>
    /// 被攻击
    /// </summary>
    /// <param name="Attacker"></param>
    public override void UnderAttack(ICharacter Attacker)
    {
        Debug.Log (m_AssetName+"被"+Attacker.m_GameObject.name+"攻击了！！！"+ Attacker.GetAttribute().GetAttStrategy().GetAtkPlusValue(m_Attribute));
        m_Attribute.CalDmgValue(Attacker.GetAttribute().GetAttStrategy().GetAtkPlusValue(m_Attribute));


        MessManager.GetInstance().SendMes("ChangeHPValue", m_Attribute.GetNowHP().ToString());
        if (IsKilled())
        {
            Killed();
        }
    }

    public override void Killed()
    {
        base.Killed();
        m_GameObject.GetComponentInChildren<Animator>().SetTrigger("Die");
    }

    // 播放音效
    public abstract void DoPlayKilledSound();

    // 播放特效
    public abstract void DoShowKilledEffect();

    public int GetLv()
    {
        return GetSoldierValue().GetSoldierLv();
    }

    public void SetLv(int lv)
    {
        GetSoldierValue().SetSoldierLv(lv);
    }

    public SpriteRenderer GetWeaponObj()
    {
        return UnityTool.FindChildGameObject(m_GameObject, "weapon01").GetComponent<SpriteRenderer>();
    }

    public  virtual void UseSkill(string v)
    {

    }
}