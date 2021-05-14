using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Res工厂的代理缓存
/// </summary>
public class ResourceAssetProxyFactory : IAssetFactory
{
	private ResourceAssetFactory m_RealFactory = null; 
	private Dictionary<string,UnityEngine.Object> m_Soldiers = null;
	private Dictionary<string,UnityEngine.Object> m_Enemys = null;
	private Dictionary<string,UnityEngine.Object> m_Weapons = null;
	private Dictionary<string,UnityEngine.Object> m_Effects = null;
	private Dictionary<string,AudioClip>		  m_Audios = null;
	private Dictionary<string, Sprite> m_Sprites = null;
	private Dictionary<string, TextAsset> m_Configs = null;

	public ResourceAssetProxyFactory()
	{
		m_RealFactory =  new ResourceAssetFactory();
		m_Soldiers = new Dictionary<string,UnityEngine.Object>();
		m_Enemys = new Dictionary<string,UnityEngine.Object>();
		m_Weapons = new Dictionary<string,UnityEngine.Object>();
		m_Effects = new Dictionary<string,UnityEngine.Object>();
		m_Audios = new Dictionary<string,AudioClip>();
		m_Sprites = new Dictionary<string,Sprite>();
		m_Configs = new Dictionary<string, TextAsset>();
	}
	
	public override GameObject LoadPlayer( string AssetName )
	{
		if( m_Soldiers.ContainsKey( AssetName )==false)
		{
			UnityEngine.Object res = m_RealFactory.LoadGameObjectFromResourcePath( ResourceAssetFactory.PlayerPath + AssetName );
			m_Soldiers.Add ( AssetName, res);
		}
		return  UnityEngine.Object.Instantiate( m_Soldiers[AssetName] ) as GameObject;
	}
	
	public override GameObject LoadEnemy( string AssetName )
	{
		if( m_Enemys.ContainsKey( AssetName )==false)
		{
			UnityEngine.Object res = m_RealFactory.LoadGameObjectFromResourcePath( ResourceAssetFactory.EnemyPath + AssetName );
			m_Enemys.Add ( AssetName, res);
		}
		return  UnityEngine.Object.Instantiate( m_Enemys[AssetName] ) as GameObject;
	}

	public override Sprite  LoadWeapon( string AssetName )
	{
		if( m_Weapons.ContainsKey( AssetName )==false)
		{
			UnityEngine.Object res = m_RealFactory.LoadSprite( ResourceAssetFactory.WeaponPath + AssetName );
			m_Weapons.Add ( AssetName, res);
		}
		return  m_Weapons[AssetName] as Sprite;
	}

	public override GameObject LoadEffect( string AssetName )
	{
		if( m_Effects.ContainsKey( AssetName )==false)
		{
			UnityEngine.Object res = m_RealFactory.LoadGameObjectFromResourcePath( ResourceAssetFactory.EffectPath + AssetName );
			m_Effects.Add ( AssetName, res);
		}
		return  UnityEngine.Object.Instantiate( m_Effects[AssetName] ) as GameObject;
	}

	public override AudioClip  LoadAudioClip(string ClipName )
	{
		if( m_Audios.ContainsKey( ClipName )==false)
		{
			UnityEngine.Object res = m_RealFactory.LoadGameObjectFromResourcePath( ResourceAssetFactory.AudioPath + ClipName );
			m_Audios.Add ( ClipName, res as AudioClip);
		}
		return m_Audios[ClipName];
	}

	public override Sprite LoadSprite(string SpriteName)
	{
		if( m_Sprites.ContainsKey( SpriteName )==false)
		{
			Sprite res = m_RealFactory.LoadSprite( SpriteName );
			m_Sprites.Add ( SpriteName, res );
		}
		return m_Sprites[SpriteName];
	}

    public override string LoadConfig(string ConfigName)
    {
		if (m_Configs.ContainsKey(ConfigName) == false)
		{
			UnityEngine.Object res = m_RealFactory.LoadGameObjectFromResourcePath(ResourceAssetFactory.ConfigPath + ConfigName);
			m_Configs.Add(ConfigName, res as TextAsset);
		}
		return m_Configs[ConfigName].text;
	}
}
