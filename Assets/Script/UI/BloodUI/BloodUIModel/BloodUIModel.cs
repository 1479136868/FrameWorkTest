using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodUIModel : IUserInterfaceModel
{
    BloodUI _view { get { return view as BloodUI; } }

    public override void Initialize()
    {
        base.Initialize();
        MessManager.GetInstance().RegisterMessage("SetCurrentEnemy", SetCurrentEnemy);
    }

    private void SetCurrentEnemy(object obj)
    {
        object[] objs = obj as object[];
        EnemyAttr attr = objs[0] as EnemyAttr;

        _view.SetCurrentEnemy(attr);
    }
}
