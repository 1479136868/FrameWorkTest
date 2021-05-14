using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGameUI : IUserInterface
{
    private Button StartGameBtn = null;

    private StartGameUICtrl _ctrl { get { return ctrl as StartGameUICtrl; } }

    public override void Initialize(string s)
    {
        m_RootUI = UnityTool.FindGameObject(s);

        // 查找开始按钮
        StartGameBtn = UnityTool.FindChildGameObject(m_RootUI, "StartGameBtn").GetComponent<Button>();


        if (StartGameBtn != null)
            StartGameBtn.onClick.AddListener(() => _ctrl.OnStartGameBtnClick(StartGameBtn));

    }


}
