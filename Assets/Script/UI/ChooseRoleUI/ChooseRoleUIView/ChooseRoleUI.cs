using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Newtonsoft.Json;
using System;


//演示衝突問題

//Hello World

//
//建议同意管理
public class ChooseRoleUI : IUserInterface
{
    //TODO  变量定义需标明权限
    /// <summary>
    /// 显示玩家角色的Item预制件
    /// </summary>
    private GameObject item;

    /// <summary>
    /// item的父类
    /// </summary>
    private Transform content;

    /// <summary>
    /// 去创建面板的按钮
    /// </summary>
    private Button CreateRoleBtn;

    /// <summary>
    /// 资源工厂
    /// </summary>
    private IAssetFactory assetFactory = GameFactory.GetAssetFactory();

    private ChooseRoleUIModel _model { get { return model as ChooseRoleUIModel; } }

    private ChooseRoleUICtrl _ctrl { get { return ctrl as ChooseRoleUICtrl; } }

    public override void Initialize(string s)
    { 
        m_RootUI = UnityTool.FindGameObject(s);

        //UITool默认找的是UIRoot下的，刚生成界面的时候，不在Root下

        item = UnityTool.FindChildGameObject(m_RootUI, "ChooseRoleItem");

        content = UITool.GetUIComponent<Transform>(m_RootUI, "ChooseContent");

        CreateRoleBtn = UITool.GetUIComponent<Button>(m_RootUI,"CreateRoleBtn");

        CreateRoleBtn.onClick.AddListener(() => {_ctrl. SwitchCreateRolePanel(); });
    }

  
    public override void Show()
    {
        base.Show();

        PlayerConfig playerConfig =_model.GetPlayerConfig();

  

        //读取不到配置，则此玩家没有角色
        if (playerConfig == null)
        {
            Debug.LogError("该账号无角色！！！");
        }
        else
        {

            for (int i = 0; i < playerConfig.players.Count; i++)
            {
                int k = i;
                GameObject clone = GameObject.Instantiate(item, content, false);
                RawImage rawImage = clone.transform.GetComponentInChildren<RawImage>();
                RenderTexture texture = new RenderTexture(245, 245, 1);
                Camera camera = clone.transform.GetComponentInChildren<Camera>();
                Transform point = clone.transform.Find("PlayerPoint");
                camera.targetTexture = texture;
                rawImage.texture = texture;
                GameObject obj = assetFactory.LoadPlayer(playerConfig.players[i].model);
                clone.GetComponentInChildren<Text>().text = playerConfig.players[i].name;
                obj.transform.SetParent(point);
                obj.transform.localPosition = Vector3.zero;
                GameObject.Destroy(obj.GetComponent<PlayerParentMove>());
                clone.GetComponent<Button>().onClick.AddListener(() => {_ctrl. StartGame(playerConfig.players[k]); });
            }

        }
        item.SetActive(false);

    }

    public override void Hide()
    {
        base.Hide();
        for (int i = 0; i < content.childCount; i++)
        {
            GameObject.Destroy(content.GetChild(i).gameObject);
        }
        item.SetActive(true);
    }

   

    public override void Release()
    {
        base.Release();
        CreateRoleBtn.onClick.RemoveAllListeners();

        m_RootUI = null;

        item = null;

        content = null;

        CreateRoleBtn = null;
    }
}
