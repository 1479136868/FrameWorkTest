using UnityEngine;
using System.Collections;

/// <summary>
/// 资源工厂
/// </summary>
public class ResourceAssetFactory : IAssetFactory 
{
	public const string PlayerPath = "Player/";
	public const string EnemyPath = "Enemy/";
	public const string WeaponPath = "Weapons/";
	public const string EffectPath = "Effects/";
	public const string AudioPath  = "Audios/";
	public const string SpritePath = "Image/";
	public const string ConfigPath = "Config/";  

	public override GameObject LoadPlayer( string AssetName )
	{	
		return InstantiateGameObject(PlayerPath + AssetName );
	}

	public override string LoadConfig(string AssetName)
	{
		UnityEngine.Object res = LoadGameObjectFromResourcePath(ConfigPath + AssetName);
		if (res == null)
			return null;
		return (res as TextAsset).text;
		   
	}

	public override GameObject LoadEnemy( string AssetName )
	{
		return InstantiateGameObject( EnemyPath + AssetName  );
	}

	public override Sprite LoadWeapon( string AssetName )
	{
		return LoadGameObjectFromResourcePath( WeaponPath +  AssetName ) as Sprite;
	}

	public override GameObject LoadEffect( string AssetName )
	{
		return InstantiateGameObject( EffectPath + AssetName);
	}

	public override AudioClip  LoadAudioClip(string ClipName)
	{
		UnityEngine.Object res = LoadGameObjectFromResourcePath(AudioPath + ClipName );
		if(res==null)
			return null;
		return res as AudioClip;
	}

	public override Sprite LoadSprite(string SpriteName)
	{
		return Resources.Load( SpriteName,typeof(Sprite)) as Sprite;
	}

	private GameObject InstantiateGameObject( string AssetName )
	{
		UnityEngine.Object res = LoadGameObjectFromResourcePath( AssetName );
		if(res==null)
			return null;
		return  UnityEngine.Object.Instantiate(res) as GameObject;
	}

	public UnityEngine.Object LoadGameObjectFromResourcePath( string AssetPath)
	{
		UnityEngine.Object res = Resources.Load(AssetPath);
		if( res == null)
		{
			Debug.LogWarning("加载路径不对劲！！！"+AssetPath);
			return null;
		}		
		return res;
	}
}
