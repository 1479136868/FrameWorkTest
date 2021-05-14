using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateOrChooseRoleManager : IGameManager
{
    private CreateOrChooseRoleManager() { }

    //------------------------------------------------------------------------
    // Singleton模版
    private static CreateOrChooseRoleManager _instance;
    public static CreateOrChooseRoleManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = new CreateOrChooseRoleManager();
            return _instance;
        }
    }
     
    public   bool isSelect = false;

    public override void Initinal()
    {
         
        IUserInterfaceManager.GetInstance().OpenUI(typeof(ChooseRoleUIConfig));

        CharacterSystem.Instance.SetGM(this);

    }

    public override void Release()
    {
        isSelect = false; 
    }

    public override void Update()
    { 

    }

   
    /// <summary>
    /// 切换成选择角色面板
    /// </summary>
    public void SwitchChooseRolePanel()
    {
        IUserInterfaceManager.GetInstance().OpenUI(typeof(ChooseRoleUIConfig));
        IUserInterfaceManager.GetInstance().CloseUI(typeof(CreateRoleUIConfig));
    }

    /// <summary>
    /// 开始游戏，当前选了角色
    /// </summary>
    public   void GameStart(Player player)
    {

        ICharacterFactory characterFactory = GameFactory.GetCharacterFactory();

        ///其实没必要用建造者模式造玩家的角色
        ISoldier soldier = characterFactory.CreateSoldier(player, Vector3.zero);

        InputSystem.Instance.SetSoldier(CharacterSystem.Instance.GetSoldier());

        CharacterSystem.Instance.HideSoldier();

        isSelect = true;
    }

}
