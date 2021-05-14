using UnityEngine;
using System.Collections;

/// <summary>
/// 抽象工厂
/// </summary>
public static class GameFactory
{
	/// <summary>
	/// 控制是否本地加载还是走网络
	/// </summary>
	private static bool   		 m_bLoadFromResource = true;

	private static ICharacterFactory m_CharacterFactory = null;
	private static IAssetFactory 	 m_AssetFactory = null;
	private static IWeaponFactory    m_WeaponFactory = null;
	private static IAttrFactory      m_AttrFactory = null;
	
	public static IAssetFactory GetAssetFactory()
	{
		if( m_AssetFactory == null)
		{
			if( m_bLoadFromResource)
				m_AssetFactory = new ResourceAssetProxyFactory(); 
		}
		return m_AssetFactory;
	}

	public static ICharacterFactory GetCharacterFactory()
	{
		if( m_CharacterFactory == null)		
			m_CharacterFactory = new CharacterFactory();
		return m_CharacterFactory;
	}

	public static IWeaponFactory GetWeaponFactory()
	{
		if( m_WeaponFactory == null)		
			m_WeaponFactory = new WeaponFactory();
		return m_WeaponFactory;
	}

	public static IAttrFactory GetAttrFactory()
	{
		if( m_AttrFactory == null)		
			m_AttrFactory = new AttrFactory();
		return m_AttrFactory;
	}	
}
