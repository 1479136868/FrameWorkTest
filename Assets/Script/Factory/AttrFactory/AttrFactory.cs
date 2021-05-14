using UnityEngine;
using System.Collections.Generic;
using System;

public class AttrFactory : IAttrFactory
{
    private Dictionary<int, BaseAttr> m_SoldierAttrDB = null;
    private Dictionary<int, EnemyBaseAttr> m_EnemyAttrDB = null;
    private Dictionary<int, WeaponAttr> m_WeaponAttrDB = null;
    private Dictionary<int, CharacterBaseAttr> m_BasicAttrDB = null;

    public AttrFactory()
    {
        InitEnemyAttr();
        InitWeaponAttr();
        InitBasicAttr();
        InitSoldierAttr();
    }

    /// <summary>
    /// 初始化基础属性
    /// </summary>
    private void InitBasicAttr()
    {

        m_BasicAttrDB = new Dictionary<int, CharacterBaseAttr>();

        //英雄的
        m_BasicAttrDB.Add(1, new CharacterBaseAttr(30, 8, "英雄"));

        //怪物的
        m_BasicAttrDB.Add(2, new CharacterBaseAttr(10, 8, "Boss"));

    }

    private void InitSoldierAttr()
    {
        m_SoldierAttrDB = new Dictionary<int, BaseAttr>();
        m_SoldierAttrDB.Add(1, new CharacterBaseAttr(80, 8.0f, "鬼剑士"));
        m_SoldierAttrDB.Add(2, new CharacterBaseAttr(80, 8.2f, "黑暗武士"));
    }

    private void InitEnemyAttr()
    {
        m_EnemyAttrDB = new Dictionary<int, EnemyBaseAttr>();

        m_EnemyAttrDB.Add(1, new EnemyBaseAttr(50, 3.0f, "Keraha", 10));
    }

    private void InitWeaponAttr()
    {
        m_WeaponAttrDB = new Dictionary<int, WeaponAttr>();

        m_WeaponAttrDB.Add(1, new WeaponAttr(20, 4, "刀"));
    }

    public override CharacterBaseAttr GetBasicAttr(int AttrID)
    {
        if (m_BasicAttrDB.ContainsKey(AttrID))
        {
            return m_BasicAttrDB[AttrID];
        }

        Debug.LogWarning("GetAdditionalAttr:AttrID[" + AttrID + "]數值不存在");
        return null;
    }

    public override EnemyAttr GetEnemyAttr(int AttrID)
    {
        if (m_EnemyAttrDB.ContainsKey(AttrID))
        {
            EnemyAttr NewAttr = new EnemyAttr();
            NewAttr.SetEnemyAttr(m_EnemyAttrDB[AttrID]);
            return NewAttr;

        }
        Debug.LogWarning("GetEnemyAttr:AttrID[" + AttrID + "]不存在");
        return null;
    }

    public override WeaponAttr GetWeaponAttr(int AttrID)
    {
        if (m_WeaponAttrDB.ContainsKey(AttrID))
        {
            return m_WeaponAttrDB[AttrID];

        }
        Debug.LogWarning("GetWeaponAttr:AttrID[" + AttrID + "]數值不存在");
        return null;
    }

    public override SoldierAttr GetSoldierAttr(int AttrID)
    {
        if (m_SoldierAttrDB.ContainsKey(AttrID)  )
        {
            SoldierAttr NewAttr = new SoldierAttr();
            NewAttr.SetSoldierAttr(m_SoldierAttrDB[AttrID]);
            return NewAttr;

        }
        Debug.LogWarning("GetSoldierAttr:AttrID[" + AttrID + "]不存在");
        return null;
    }
}