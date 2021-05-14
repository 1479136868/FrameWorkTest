using UnityEngine;
using System.Collections;

/// <summary>
/// 敌人建造者参数
/// </summary>
public class EnemyBuildParam : ICharacterBuildParam
{
	public int attrID;


	public EnemyBuildParam()
	{
	}
}

/// <summary>
/// 敌人的建造者
/// </summary>
public class EnemyBuilder : ICharacterBuilder
{
	private EnemyBuildParam m_BuildParam = null;



	public override void SetBuildParam( ICharacterBuildParam theParam )
	{
		m_BuildParam = theParam as EnemyBuildParam;	
	}
	 
	public override void LoadAsset( int GameObjectID )
	{
		IAssetFactory AssetFactory = GameFactory.GetAssetFactory();
		GameObject EnemyGameObject = AssetFactory.LoadEnemy( m_BuildParam.NewCharacter.GetAssetName() );
		EnemyGameObject.transform.position = m_BuildParam.SpawnPosition;
		EnemyGameObject.gameObject.name = string.Format("Enemy[{0}]",GameObjectID);
		m_BuildParam.NewCharacter.SetGameObject( EnemyGameObject );
	}
	 
	public override void SetCharacterAttr()
	{ 
		IAttrFactory theAttrFactory = GameFactory.GetAttrFactory();
		int AttrID = m_BuildParam.NewCharacter.GetAttrID();
		EnemyAttr theEnemyAttr = theAttrFactory.GetEnemyAttr( AttrID ); 
		 
		theEnemyAttr.SetAttStrategy( new EnemyAttrStrategy() );



		 
        m_BuildParam.NewCharacter.SetCharacterAttr( theEnemyAttr );
	}

	/// <summary>
	/// 加入管理器
	/// </summary>
	/// <param name="GM"></param>
	public override void AddCharacterSystem(IGameManager GM)
	{
		 CharacterSystem.Instance.AddEnemy( m_BuildParam.NewCharacter as IEnemy );
	}
	 

    public override void SetAI()
    {
		EnemyAI theAI = new EnemyAI(m_BuildParam.NewCharacter );
		m_BuildParam.NewCharacter.SetAI(theAI);
	}

	public override void SetWeapon()
	{

	}
}
