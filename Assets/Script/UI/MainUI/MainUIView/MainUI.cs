using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class MainUI : IUserInterface
{
    private Slider Hp = null;
    private Slider Mp = null;

    private Text HPText = null;
    private Text MPText = null;

    /// <summary>
    /// 背包按钮
    /// </summary>
    private Button bagBtn = null;

    /// <summary>
    /// 角色信息面板
    /// </summary>
    private Button characterInfoBtn = null;

    /// <summary>
    /// 技能Content
    /// </summary>
    private Transform SkillContent = null;

    private MainUICtrl _ctrl { get { return ctrl as MainUICtrl; } }

    private MainUIModel _model { get { return model as MainUIModel; } }



    /// <summary>
    /// 初始化
    /// </summary>
    public override void Initialize(string s)
    {
        m_RootUI = UnityTool.FindGameObject(s);

        bagBtn = UITool.GetUIComponent<Button>(m_RootUI, "UIBagBtn");

        Hp = UITool.GetUIComponent<Slider>(m_RootUI, "HP");

        Mp = UITool.GetUIComponent<Slider>(m_RootUI, "MP");

        HPText = UITool.GetUIComponent<Text>(m_RootUI, "HPText");

        MPText = UITool.GetUIComponent<Text>(m_RootUI, "MPText");

        SkillContent = UITool.GetUIComponent<Transform>(m_RootUI, "SkillContent");

        bagBtn.onClick.AddListener(_ctrl.OnBagBtnClick);


        for (int i = 0; i < SkillContent.childCount; i++)
        {
            int k = i;
            Transform obj = SkillContent.GetChild(i);
            obj.GetComponent<Button>().onClick.RemoveAllListeners();
            obj.GetComponent<Button>().onClick.AddListener(() =>
            {
                _ctrl.UseSkill(k, obj);
            });

        }
    }


    /// <summary>
    /// 设置血量与蓝量的最大值,且初始化
    /// </summary>
    /// <param name="maxHp">血量最大值</param>
    /// <param name="maxMp">蓝量最大值</param>
    public void SetMaxHpAndMp(int maxHp , int maxMp)
    {
    

        Hp.maxValue = maxHp;
        Mp.maxValue = maxMp;

        Hp.value = maxHp;
        Mp.value = maxMp;

        HPText.text = "100%";
        MPText.text = "100%";
    }

    /// <summary>
    /// 改变HP
    /// </summary>
    /// <param name="hp"></param>
    public void ChangeHPValue(int hp)
    {
        Hp.value = hp;
        HPText.text = (Hp.value / Hp.maxValue) * 100 + "%";
    }

    /// <summary>
    /// 改变MP
    /// </summary>
    /// <param name="mp"></param>
    public void ChangeMPValue(int mp)
    {
        Mp.value = mp;
        MPText.text = (Mp.value / Mp.maxValue) * 100 + "%";
    }


    public override void Update()
    {
        base.Update();
    }

    public override void Release()
    {
        base.Release();
        characterInfoBtn.onClick.RemoveAllListeners();
        bagBtn.onClick.RemoveAllListeners();
        characterInfoBtn = null;
        bagBtn = null;
        Hp = null;
        Mp = null;
    }
}
