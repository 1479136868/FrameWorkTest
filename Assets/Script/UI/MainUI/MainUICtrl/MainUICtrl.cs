using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUICtrl : IUserInterfaceCtrl
{
    public override void Initialize()
    {
        base.Initialize();
    }

    public override void Update()
    {
        base.Update();
    }

    public override void Release()
    {
        base.Release();
    }

    /// <summary>
    /// 点击背包按钮
    /// </summary>
    public void OnBagBtnClick()
    {
        IUserInterfaceManager.GetInstance().OpenUI(typeof(BagUIConfig));
    }

    public void UseSkill(int k, Transform trans)
    {
        if (!BattleManager.Instance.ThisGameIsOver())
        {
            CharacterSystem.Instance.GetSoldier().UseSkill((k + 1).ToString());
            CharacterSystem.Instance.GetSoldier().GetGameObject().GetComponent<PlayerParentMove>().isAttack = true;
        }
    }


    /// <summary>
    /// 点击角色信息按钮
    /// </summary>
    public void OnCharacterInfoBtnClick()
    {
        Debug.LogError("打开角色面板！！！");
    }

}
