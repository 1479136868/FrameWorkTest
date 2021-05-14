using UnityEngine;
using System.Collections;

/// <summary>
/// 武器的开火，使用模板方法模式
/// 使用刀，需要在一定范围才能对敌人造成伤害
/// </summary>
public class WeaponKnife : IWeapon 
{
	public WeaponKnife()
	{
		m_emWeaponType = ENUM_Weapon.Knife;
	}


    protected override void DoShowBulletEffect(ICharacter theTarget)
    {


	}

    protected override void DoShowSoundEffect()
	{
		ShowSoundEffect("GunShot");
	}
}
