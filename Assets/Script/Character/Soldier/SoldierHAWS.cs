using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierHAWS : ISoldier
{
    public SoldierHAWS()
    {
        m_emSoldier = ENUM_Role.黑暗武士;
        m_AssetName = "黑暗武士";
        m_AttrID = 2;
        m_IconSpriteName = "黑暗武士";
    }

    public override void DoPlayKilledSound()
    {
    }

    public override void DoShowKilledEffect()
    {
    }
}
