using UnityEngine;
using System.Collections;

/// <summary>
/// 享元的基础属性
/// </summary>
public abstract class BaseAttr
{			
	public abstract int 	GetMaxHP();
	public abstract float 	GetMoveSpeed();
	public abstract string 	GetAttrName();
}

/// <summary>
/// 基本角色属性
/// </summary>
public class CharacterBaseAttr : BaseAttr
{
	/// <summary>
	/// HP最大值
	/// </summary>
	private int 	m_MaxHP;	 

	/// <summary>
	/// 移动速度
	/// </summary>
	private float  	m_MoveSpeed;
	
	/// <summary>
	/// 名字
	/// </summary>
	private string 	m_AttrName;		 

	public CharacterBaseAttr(int MaxHP,float MoveSpeed, string AttrName)
	{
		m_MaxHP = MaxHP;
		m_MoveSpeed = MoveSpeed;
		m_AttrName = AttrName;
	}

	public override int GetMaxHP()
	{
		return m_MaxHP;
	}

	public override float GetMoveSpeed()
	{
		return m_MoveSpeed;
	}

	public override string GetAttrName()
	{
		return m_AttrName;
	}
}

/// <summary>
/// 敌人的基本数值
/// </summary>
public class EnemyBaseAttr : CharacterBaseAttr
{
	/// <summary>
	/// 暴击率
	/// </summary>
	public int 	m_InitCritRate; 

	public EnemyBaseAttr(int MaxHP,float MoveSpeed, string AttrName, int CritRate):base(MaxHP,MoveSpeed,AttrName)
	{
		m_InitCritRate =CritRate;
	}

	public virtual int GetInitCritRate()
	{
		return m_InitCritRate;
	}
}



