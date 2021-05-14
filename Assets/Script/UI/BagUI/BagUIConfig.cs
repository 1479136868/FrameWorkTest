using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagUIConfig : IUserInterfaceConfig
{
    public BagUIConfig()  
    {
        prefab_Path = "BagUI";

        View = new BagUI();
        Ctrl = new BagUICtrl();
        Model = new BagUIModel();

        layer = ENUM_UILayer.Normal;
        InitConfig();
    }
}
