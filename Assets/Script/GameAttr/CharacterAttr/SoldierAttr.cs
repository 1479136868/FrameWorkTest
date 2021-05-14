using UnityEngine;
using System.Collections;

/// <summary>
/// 士兵享元组件
/// </summary>
public class SoldierAttr : ICharacterAttr
{
	/// <summary>
	/// 士兵等级
	/// </summary>
	protected int 	m_SoldierLv;  

	/// <summary>
	/// 士兵增加的HP
	/// </summary>
	protected int	m_AddMaxHP; 

	public SoldierAttr()
	{}
	 
	public void SetSoldierAttr(BaseAttr BaseAttr)
	{ 
		base.SetBaseAttr( BaseAttr );
		 
		m_SoldierLv = 1;
		m_AddMaxHP = 0;
	}
	
	/// <summary>
	/// 设置士兵等级
	/// </summary>
	/// <param name="Lv">等级</param>
	public void SetSoldierLv(int Lv)
	{
		m_SoldierLv = Lv;
	}

	/// <summary>
	/// 获取士兵等级
	/// </summary>
	/// <returns></returns>
	public int GetSoldierLv()
	{
		return m_SoldierLv ;
	}

	/// <summary>
	/// 获取最大HP
	/// </summary>
	/// <returns></returns>
	public override int GetMaxHP()
	{
		return base.GetMaxHP() + m_AddMaxHP;
	}

	/// <summary>
	/// 增加HP最大值
	/// </summary>
	/// <param name="AddMaxHP"></param>
	public void AddMaxHP(int AddMaxHP)
	{
		m_AddMaxHP = AddMaxHP;
	}



}
