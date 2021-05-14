using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectStageUIConfig : IUserInterfaceConfig
{
    public SelectStageUIConfig() 
    {
        prefab_Path = "SelectStageUI";

        View = new SelectStageUI();
        Ctrl = new SelectStageUICtrl();
        Model = new SelectStageUIModel();

        layer = ENUM_UILayer
            .Normal;
        InitConfig();
    }
}
