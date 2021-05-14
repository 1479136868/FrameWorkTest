using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// 数值工厂
/// </summary>
public abstract class IAttrFactory
{ 
	public abstract EnemyAttr GetEnemyAttr(int AttrID);

    public abstract WeaponAttr GetWeaponAttr(int AttrID);

    public abstract CharacterBaseAttr GetBasicAttr(int AttrID);

    public abstract SoldierAttr GetSoldierAttr(int attrID);
}
