using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// 玩家角色AI
/// </summary>
public class SoldierAI : ICharacterAI 
{	
	public SoldierAI(ICharacter Character):base(Character)
	{
		//设置最初状态
		ChangeAIState(new IdleAIState());
	} 
}

