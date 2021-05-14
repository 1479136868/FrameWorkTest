using UnityEngine;
using System.Collections;

/// <summary>
/// 敌人数值策略
/// </summary>
public class EnemyAttrStrategy : IAttrStrategy 
{
	/// <summary>
	/// 初始化
	/// </summary>
	/// <param name="CharacterAttr"></param>
	public override void InitAttr( ICharacterAttr CharacterAttr )
	{

	}
	
	/// <summary>
	/// 获取攻击加成
	/// </summary>
	/// <param name="CharacterAttr"></param>
	/// <returns></returns>
	public override int GetAtkPlusValue( ICharacterAttr CharacterAttr )
	{
		 
		return 10;
	}
	
	/// <summary>
	/// 获取减伤
	/// </summary>
	/// <param name="CharacterAttr"></param>
	/// <returns></returns>
	public override int GetDmgDescValue( ICharacterAttr CharacterAttr )
	{ 
		return 0;
	}

}
