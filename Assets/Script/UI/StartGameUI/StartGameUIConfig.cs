using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameUIConfig : IUserInterfaceConfig
{
    public StartGameUIConfig() 
    {
        prefab_Path = "StartGameUI";

        View = new StartGameUI();
        Ctrl = new StartGameUICtrl();
        Model = new StartGameUIModel();

        



        layer = ENUM_UILayer.Normal;
        InitConfig();
    }
}
