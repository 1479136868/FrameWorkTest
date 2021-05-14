using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectStageUIModel : IUserInterfaceModel
{
    public List<StageInfo> GetStageInfo()
    {
        return MainManager.Instance.GetStageInfo();
    }
}