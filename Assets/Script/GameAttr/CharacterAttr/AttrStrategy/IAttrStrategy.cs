using UnityEngine;
using System.Collections;

/// <summary>
/// 数值计算策略
/// </summary>
public abstract class IAttrStrategy
{
	/// <summary>
	/// 初始化数值
	/// </summary>
	/// <param name="CharacterAttr"></param>
	public abstract void InitAttr( ICharacterAttr CharacterAttr );
	
	/// <summary>
	/// 计算攻击加成
	/// </summary>
	/// <param name="CharacterAttr"></param>
	/// <returns></returns>
	public abstract int GetAtkPlusValue( ICharacterAttr CharacterAttr );
	
	/// <summary>
	/// 获取伤害减免
	/// </summary>
	/// <param name="CharacterAttr"></param>
	/// <returns></returns>
	public abstract int GetDmgDescValue( ICharacterAttr CharacterAttr );
}
