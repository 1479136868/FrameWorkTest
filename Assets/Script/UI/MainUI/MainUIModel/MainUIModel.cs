using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUIModel : IUserInterfaceModel
{
    private MainUI _view { get { return view as MainUI; } }


    public override void Initialize()
    {
        base.Initialize();


        MessManager.GetInstance().RegisterMessage("SetMaxHpAndMp", SetMaxHpAndMp);
        MessManager.GetInstance().RegisterMessage("ChangeHPValue", ChangeHPValue);
        MessManager.GetInstance().RegisterMessage("ChangeMPValue", ChangeMPValue);

    }

    private void ChangeMPValue(object obj)
    {
        int mp = int.Parse((obj as object[])[0] as string);
        _view.ChangeMPValue(mp);
    }

    private void ChangeHPValue(object obj)
    {
        int hp = int.Parse((obj as object[])[0] as string);
        _view.ChangeHPValue(hp);
    }

    private void SetMaxHpAndMp(object obj)
    {
        object[] vs = obj as object[];

        int maxHp = int.Parse(vs[0].ToString());
        int maxMp = int.Parse(vs[1].ToString());

        _view.SetMaxHpAndMp(maxHp, maxMp);
    }

    public override void Update()
    {
        base.Update();
    }

    public override void Release()
    {
        base.Release();
    }
}
