using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseRoleUIModel : IUserInterfaceModel
{
    public PlayerConfig GetPlayerConfig()
    {
  return      ConfigManager.GetInstance().GetPlayerConfig();
    }
}