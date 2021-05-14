using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseRoleUICtrl : IUserInterfaceCtrl
{
    public void SwitchCreateRolePanel()
    {
        IUserInterfaceManager.GetInstance().CloseUI(typeof(ChooseRoleUIConfig));
        IUserInterfaceManager.GetInstance().OpenUI(typeof(CreateRoleUIConfig));
    }

    public void StartGame(Player player)
    {
        IUserInterfaceManager.GetInstance().CloseUI(typeof(ChooseRoleUIConfig));
        CreateOrChooseRoleManager.Instance.GameStart(player);
    }
}
