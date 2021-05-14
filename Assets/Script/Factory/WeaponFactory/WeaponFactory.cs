using UnityEngine;
using System.Collections;

/// <summary>
/// 武器工厂
/// </summary>
public class WeaponFactory : IWeaponFactory
{
    public WeaponFactory()
    {
    }

    // 建立武器
    public override IWeapon CreateWeapon(ENUM_Weapon emWeapon)
    {
        IWeapon pWeapon = null;
        string AssetName = "";
        int AttrID = 0;

        //根据武器类型建立
        switch (emWeapon)
        {
            case ENUM_Weapon.Knife:
                pWeapon = new WeaponKnife();
                AssetName = "5";
                AttrID = 1;
                break;
            default:
                Debug.LogWarning("创建[" + emWeapon + "]失败！！！");
                return null;
        }

        // 加载武器资源
        IAssetFactory AssetFactory = GameFactory.GetAssetFactory();
        Sprite WeaponGameObjet = AssetFactory.LoadWeapon(AssetName);

        pWeapon.SetIWeapon(WeaponGameObjet);

        // 设置武器的威力
        IAttrFactory theAttrFactory = GameFactory.GetAttrFactory();
        WeaponAttr theWeaponAttr = theAttrFactory.GetWeaponAttr(AttrID);

        pWeapon.SetWeaponAttr(theWeaponAttr);

        return pWeapon;
    }

}
