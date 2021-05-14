using UnityEngine;
using System.Collections;

/// <summary>
/// 角色建造者需要的参数
/// </summary>
public class SoldierBuildParam : ICharacterBuildParam
{
    /// <summary>
    /// 角色等级
    /// </summary>
    public int Lv = 0;

    public SoldierBuildParam()
    {
    }
}

/// <summary>
/// 角色建造者
/// </summary>
public class SoldierBuilder : ICharacterBuilder
{
    private SoldierBuildParam m_BuildParam = null;

    public override void SetBuildParam(ICharacterBuildParam theParam)
    {
        m_BuildParam = theParam as SoldierBuildParam;
    }

    public override void LoadAsset(int GameObjectID)
    {
        IAssetFactory AssetFactory = GameFactory.GetAssetFactory();
        GameObject SoldierGameObject = AssetFactory.LoadPlayer(m_BuildParam.NewCharacter.GetAssetName());
        SoldierGameObject.transform.position = m_BuildParam.SpawnPosition;
        SoldierGameObject.gameObject.name = string.Format("Soldier[{0}]", GameObjectID);
        m_BuildParam.NewCharacter.SetGameObject(SoldierGameObject);
    }

    /// <summary>
    /// 设置角色属性
    /// </summary>
    public override void SetCharacterAttr()
    {  
        IAttrFactory theAttrFactory = GameFactory.GetAttrFactory();
        int AttrID = m_BuildParam.NewCharacter.GetAttrID();
        SoldierAttr theSoldierAttr = theAttrFactory.GetSoldierAttr(AttrID);



        //m_BuildParam.NewCharacter.SetCharacterAttr(theSoldierAttr);

        theSoldierAttr.SetAttStrategy(new SoldierAttrStrategy());


        theSoldierAttr.SetSoldierLv(m_BuildParam.Lv); 

        m_BuildParam.NewCharacter.SetCharacterAttr(theSoldierAttr);

    }


    /// <summary>
    ///  加入角色管理器
    /// </summary>
    /// <param name="GM"></param>
    public override void AddCharacterSystem(IGameManager GM)
    {
        CharacterSystem.Instance.SetSoldier(m_BuildParam.NewCharacter as ISoldier);
    }

    public override void SetWeapon()
    {
        IWeaponFactory WeaponFactory = GameFactory.GetWeaponFactory();
        //从工厂加载武器
        IWeapon Weapon = WeaponFactory.CreateWeapon(m_BuildParam.emWeapon);
        //设置武器的挂载点
        Weapon.SetGameObject((m_BuildParam.NewCharacter as ISoldier).GetWeaponObj());
        //显示武器
        Weapon.ShowWeapon();
        m_BuildParam.NewCharacter.SetWeapon(Weapon);
    }

    public override void SetAI()
    {

    }
}