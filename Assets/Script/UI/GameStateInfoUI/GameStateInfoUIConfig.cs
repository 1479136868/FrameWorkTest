using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateInfoUIConfig : IUserInterfaceConfig
{
    public GameStateInfoUIConfig() 
    {
        prefab_Path = "GameStateInfoUI";

        View = new GameStateInfoUI();
        Ctrl = new GameStateInfoUICtrl();
        Model = new GameStateInfoUIModel();

        layer = ENUM_UILayer.Normal;
        InitConfig();
    }
}
