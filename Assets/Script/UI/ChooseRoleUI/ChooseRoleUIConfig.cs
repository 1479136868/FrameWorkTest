using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseRoleUIConfig : IUserInterfaceConfig
{
    public ChooseRoleUIConfig() 
    {
        prefab_Path = "ChooseRoleUI";

        View = new ChooseRoleUI();
        Ctrl = new ChooseRoleUICtrl();
        Model = new ChooseRoleUIModel();

        layer = ENUM_UILayer.Normal;
        InitConfig();
    }
}
