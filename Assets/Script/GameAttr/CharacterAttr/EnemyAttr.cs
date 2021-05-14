using UnityEngine;
using System.Collections;

/// <summary>
/// 敌人享元组件
/// </summary>
public class EnemyAttr : ICharacterAttr
{ 
	public EnemyAttr()
	{}
	 
	public void SetEnemyAttr(EnemyBaseAttr EnemyBaseAttr)
	{ 
		base.SetBaseAttr( EnemyBaseAttr );
		  
	}
	 
}
