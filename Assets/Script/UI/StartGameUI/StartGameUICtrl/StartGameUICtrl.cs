using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGameUICtrl : IUserInterfaceCtrl
{
    /// <summary>
    /// 开始游戏
    /// </summary>
    /// <param name="theButton"></param>
    public void OnStartGameBtnClick(Button theButton)
    {
        //不建议
        MessManager.GetInstance().SendMes("SwitchState", "CreateOrChooseRoleScene");

        IUserInterfaceManager.GetInstance().CloseUI(typeof(StartGameUIConfig));
    }
}
