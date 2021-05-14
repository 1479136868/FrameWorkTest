using UnityEngine;
using System.Collections;

/// <summary>
/// 武器工厂
/// </summary>
public abstract class IWeaponFactory
{
	public abstract IWeapon CreateWeapon( ENUM_Weapon emWeapon);
}

