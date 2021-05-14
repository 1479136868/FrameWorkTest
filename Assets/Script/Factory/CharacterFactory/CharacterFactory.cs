using UnityEngine;
using System.Collections;

/// <summary>
/// 游戏角色工厂
/// </summary>
public class CharacterFactory : ICharacterFactory
{
    private CharacterBuilderSystem m_BuilderDirector = new CharacterBuilderSystem(BattleManager.Instance);

    public override ISoldier CreateSoldier(Player player, Vector3 SpawnPosition)
    {
        SoldierBuildParam SoldierParam = new SoldierBuildParam();

        switch (player.roleType)
        {
            case ENUM_Role.鬼剑士:
                SoldierParam.NewCharacter = new SoldierGJS();
                break;
            case ENUM_Role.黑暗武士:
                SoldierParam.NewCharacter = new SoldierHAWS();
                break;
            default:
                Debug.LogWarning("无法创建[" + player.roleType.ToString() + "]");
                return null;
        }

        if (SoldierParam.NewCharacter == null)
            return null;


        SoldierParam.emWeapon = player.roleWeapon;
        SoldierParam.SpawnPosition = SpawnPosition;
        SoldierParam.Lv = player.level;
        SoldierParam.AssetName = player.model;
        SoldierParam.IconSpriteName = player.icon;

        SoldierBuilder theSoldierBuilder = new SoldierBuilder();
        theSoldierBuilder.SetBuildParam(SoldierParam);


        m_BuilderDirector.Construct(theSoldierBuilder);

        return SoldierParam.NewCharacter as ISoldier;

    }


    public override IEnemy CreateEnemy(ENUM_Enemy emEnemy, Vector3 SpawnPosition)
    {

        EnemyBuildParam EnemyParam = new EnemyBuildParam();


        switch (emEnemy)
        {
            case ENUM_Enemy.Keraha:
                EnemyParam.NewCharacter = new EnemyKeraha();
                break;
            default:
                Debug.LogWarning("无法创建[" + emEnemy + "]");
                return null;
        }

        if (EnemyParam.NewCharacter == null)
            return null;


        EnemyParam.SpawnPosition = SpawnPosition;


        EnemyBuilder theEnemyBuilder = new EnemyBuilder();
        theEnemyBuilder.SetBuildParam(EnemyParam);


        m_BuilderDirector.Construct(theEnemyBuilder);
        return EnemyParam.NewCharacter as IEnemy;
    }

}


