using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRoleUIModel : IUserInterfaceModel
{
    public List<RoleBasicInfo> GetRoleBasicInfoConfig()
    {
        return ConfigManager.GetInstance().GetRoleBasicInfoConfig();
    }
}
