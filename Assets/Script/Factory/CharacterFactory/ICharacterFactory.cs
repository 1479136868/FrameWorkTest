using UnityEngine;
using System.Collections;

/// <summary>
/// 角色工厂
/// </summary>
public abstract class ICharacterFactory
{
	public abstract ISoldier CreateSoldier(Player player,  Vector3 SpawnPosition);
	
	public abstract IEnemy CreateEnemy( ENUM_Enemy emEnemy , Vector3 SpawnPosition );
	
}

