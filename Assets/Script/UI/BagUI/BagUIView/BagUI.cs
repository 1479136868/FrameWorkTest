using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class BagUI : IUserInterface
{
    BagUICtrl _ctrl { get { return ctrl as BagUICtrl; } }

    private Button closeBtn = null;

    public override void Initialize(string s)
    {
        m_RootUI = UnityTool.FindGameObject(s);

        closeBtn = UITool.GetUIComponent<Button>(m_RootUI, "CloseBtn");

        closeBtn.onClick.AddListener(_ctrl.OnCloseBtnClick);

    }


    public override void Release()
    {
        base.Release();
    }

    public override void Update()
    {
        base.Update();
    }
}

