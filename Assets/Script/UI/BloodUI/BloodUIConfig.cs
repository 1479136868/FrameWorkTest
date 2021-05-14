using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodUIConfig : IUserInterfaceConfig
{
    public BloodUIConfig()  
    {
        prefab_Path = "BloodUI";

        View = new BloodUI();
        Ctrl = new BloodUICtrl();
        Model = new BloodUIModel();

        layer = ENUM_UILayer.Normal;
        InitConfig();
    }
}
