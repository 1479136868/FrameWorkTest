using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectStageUI : IUserInterface
{
    private Button closeBtn = null;

    private GameObject item;

    private Transform content;

    private SelectStageUICtrl _ctrl { get { return ctrl as SelectStageUICtrl; } }

    private SelectStageUIModel _model { get { return model as SelectStageUIModel; } }

    public override void Initialize(string s)
    {
        m_RootUI = UnityTool.FindGameObject(s);

        closeBtn = UITool.GetUIComponent<Button>(m_RootUI, "SelectStageCloseBtn");

        item = UnityTool.FindChildGameObject(m_RootUI, "Item");

        content = UITool.GetUIComponent<Transform>(m_RootUI, "Content");

        closeBtn.onClick.AddListener(() => { _ctrl.OnCloseBtnClick(); });


    }


    public override void Release()
    {
        base.Release();
    }

    public override void Update()
    {
        base.Update();
    }

    /// <summary>
    /// 展示的时候，从关卡系统读取数据
    /// </summary>
    public override void Show()
    {
        base.Show();

        List<StageInfo> infos = _model.GetStageInfo(); 

        if (infos != null && infos.Count > 0)
        {
            for (int i = 0; i < infos.Count; i++)
            {
                int k = i;
                GameObject clone = GameObject.Instantiate(item, content, false);
                clone.GetComponentInChildren<Text>().text = infos[k].Icon;
                clone.GetComponent<Button>().onClick.AddListener(() => {_ctrl. StageBegin(infos[k]); });
            }
        }
        else
        {
            Debug.LogError("kong");
        }

    }

  
    public override void Hide()
    {
        for (int i = 0; i < content.childCount; i++)
        {
            GameObject.Destroy(content.GetChild(i).gameObject);
        }
        base.Hide();
    }

}
