using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRoleUIConfig : IUserInterfaceConfig
{
    public CreateRoleUIConfig()
    {
        prefab_Path = "CreateRoleUI";

        View = new CreateRoleUI();
        Ctrl = new CreateRoleUICtrl();
        Model = new CreateRoleUIModel();

        layer = ENUM_UILayer.Normal;
        InitConfig();
    }
}
