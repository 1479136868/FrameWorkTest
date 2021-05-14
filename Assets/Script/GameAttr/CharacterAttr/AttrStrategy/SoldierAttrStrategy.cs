using UnityEngine;
using System.Collections;

/// <summary>
/// 士兵数值的策略
/// </summary>
public class SoldierAttrStrategy : IAttrStrategy 
{ 
	public override void InitAttr( ICharacterAttr CharacterAttr )
	{
		 
	}
	 
	public override int GetAtkPlusValue( ICharacterAttr CharacterAttr )
	{
		return 20;
	}
	 
	public override int GetDmgDescValue( ICharacterAttr CharacterAttr )
	{
		return 0;
	}

}
