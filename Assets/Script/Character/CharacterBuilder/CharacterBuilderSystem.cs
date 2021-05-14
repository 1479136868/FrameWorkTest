using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// 角色建造系统
/// </summary>
public class CharacterBuilderSystem : IGameSystem
{
	private int m_GameObjectID = 0;

	public CharacterBuilderSystem(IGameManager GM):base(GM)
	{}

	public override void Initialize()
	{}

	public override void Update()
	{}

	/// <summary>
	/// 建造方法（流程）
	/// </summary>
	/// <param name="theBuilder"></param>
	public void Construct(ICharacterBuilder theBuilder)
	{ 
		//加载角色资源
		theBuilder.LoadAsset( ++m_GameObjectID );
		//加载武器资源
		theBuilder.SetWeapon();
		//设置属性
		theBuilder.SetCharacterAttr();
		//设置AI
		theBuilder.SetAI();
		// 加入管理器
		theBuilder.AddCharacterSystem( m_GM );
	}
}
