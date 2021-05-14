using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;
using Newtonsoft.Json;

//TODO  建议同意管理
public class CreateRoleUI : IUserInterface
{
    /// <summary>
    /// 创建角色的Item按钮
    /// </summary>
    private GameObject item;

    /// <summary>
    /// 当前展示的角色
    /// </summary>
    private Image showRole;

    /// <summary>
    /// 名字的输入框
    /// </summary>
    public InputField input;

    /// <summary>
    /// 检测名字是否重复的按钮
    /// </summary>
    private Button RepeatBtn;

    /// <summary>
    /// 确定按钮
    /// </summary>
    private Button ConfirmBtn;

    /// <summary>
    /// 取消按钮
    /// </summary>
    private Button CancelBtn;

    /// <summary>
    /// 取消按钮
    /// </summary>
    public GameObject tips;

    /// <summary>
    /// 返回按钮
    /// </summary>
    private Button GoBackBtn;

    /// <summary>
    /// 按钮的Content
    /// </summary>
    private Transform content;

    /// <summary>
    /// 提示框
    /// </summary>
    public GameObject pop;

    /// <summary>
    /// 当前要创建的职业类型(默认为第一个职业)
    /// </summary>
    public ENUM_Role currentType;

    /// <summary>
    /// POP的弹出计时
    /// </summary>
    float timer = 0f;


    private CreateRoleUIModel _model { get { return model as CreateRoleUIModel; } }

    private CreateRoleUICtrl _ctrl { get { return ctrl as CreateRoleUICtrl; } }

    public override void Initialize(string s)
    {

        m_RootUI = UnityTool.FindGameObject(s);

        tips = UnityTool.FindChildGameObject(m_RootUI, "Tips");
        item = UnityTool.FindChildGameObject(m_RootUI, "CreateRoleItemBtn");

        pop = UnityTool.FindChildGameObject(m_RootUI, "Pop");

        GoBackBtn = UITool.GetUIComponent<Button>(m_RootUI, "GoBackBtn");
        RepeatBtn = UITool.GetUIComponent<Button>(m_RootUI, "RepeatBtn");
        ConfirmBtn = UITool.GetUIComponent<Button>(m_RootUI, "ConfirmBtn");
        CancelBtn = UITool.GetUIComponent<Button>(m_RootUI, "CancelBtn");

        showRole = UITool.GetUIComponent<Image>(m_RootUI, "ShowRole");

        input = UITool.GetUIComponent<InputField>(m_RootUI, "InputField");

        content = UITool.GetUIComponent<Transform>(m_RootUI, "CreateContent");

        pop.SetActive(false);



        //根据基础信息生成可以创建的角色
        List<RoleBasicInfo> roleBasicInfoList = _model.GetRoleBasicInfoConfig(); 

        for (int i = 0; i < roleBasicInfoList.Count; i++)
        {
            int k = i;
            GameObject clone = GameObject.Instantiate(item, content, false);
            clone.GetComponentInChildren<Text>().text = roleBasicInfoList[k].name;
            clone.GetComponent<Button>().onClick.AddListener(() =>
            {
                tips.SetActive(true);
                showRole.sprite = Resources.Load<Sprite>("RoleShow/" + roleBasicInfoList[k].model);
                currentType = roleBasicInfoList[k].roleType;
            });
        }

        currentType = roleBasicInfoList[0].roleType;

        GoBackBtn.onClick.AddListener(() => {_ctrl. SwitchChooseRolePanel(); });

        RepeatBtn.onClick.AddListener(() => {_ctrl. OnRepeatBtnClick(input.text); });

        ConfirmBtn.onClick.AddListener(() => {_ctrl. OnConfirmBtnClick(input.text); });

        CancelBtn.onClick.AddListener(() => {_ctrl. OnCancelBtnClick(); });

    }

  
    public override void Release()
    {
        base.Release();

        GoBackBtn.onClick.RemoveAllListeners();

        RepeatBtn.onClick.RemoveAllListeners();

        ConfirmBtn.onClick.RemoveAllListeners();

        CancelBtn.onClick.RemoveAllListeners();

        m_RootUI = null;
        tips = null;
        item = null;

        GoBackBtn = null;
        RepeatBtn = null;
        ConfirmBtn = null;
        CancelBtn = null;
        showRole = null;
        input = null;
        content = null;

    }


  

    public override void Update()
    {
        if (pop.activeSelf)
        {
            timer += Time.deltaTime;
            if (timer >= 3)
            {
                timer = 0;
                pop.SetActive(false);
            }
        }
    }
}
