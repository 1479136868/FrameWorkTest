using UnityEngine;
using System.Collections;

/// <summary>
/// 建造角色需要的参数
/// </summary>
public abstract class ICharacterBuildParam
{
	public ENUM_Weapon  emWeapon = ENUM_Weapon.Null;
	public ICharacter   NewCharacter = null;		
	public Vector3      SpawnPosition; 
	public string       AssetName;
	public string       IconSpriteName;            
}

/// <summary>
/// 建造角色
/// </summary>
public abstract class ICharacterBuilder
{

	/// <summary>
	/// 设置建造参数
	/// </summary>
	/// <param name="theParam"></param>
	public abstract void SetBuildParam( ICharacterBuildParam theParam );

	/// <summary>
	/// 加载资源模型
	/// </summary>
	/// <param name="GameObjectID"></param>
	public abstract void LoadAsset	( int GameObjectID ); 

	/// <summary>
	/// 添加武器
	/// </summary>
	public abstract void SetWeapon	();

	/// <summary>
	/// 添加AI
	/// </summary>
	public abstract void SetAI		();

	/// <summary>
	/// 设置角色的公共属性
	/// </summary>
	public abstract void SetCharacterAttr();

	/// <summary>
	/// 加入角色管理器
	/// </summary>
	/// <param name="GM"></param>
	public abstract void AddCharacterSystem(IGameManager GM ); 
}

