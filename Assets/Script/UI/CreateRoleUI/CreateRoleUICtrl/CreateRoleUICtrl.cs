using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRoleUICtrl : IUserInterfaceCtrl
{
    private CreateRoleUI  _view { get { return view as CreateRoleUI ; } }

    /// <summary>
    /// 检测是否重名
    /// </summary>
    /// <param name="name">姓名</param>
    public void OnRepeatBtnClick(string name)
    {
        if (CheckRoleName(name))
        {
            Debug.LogWarning("名字合法且不重复！！！");
        }
        else
        {
            Debug.LogError("名字不合法或重复！！！");

            _view. pop.SetActive(true);

        }
    }

    /// <summary>
    /// 创建角色确认按钮
    /// </summary>
    public void OnConfirmBtnClick(string name)
    {
        //判断名字是否合法
        if (CheckRoleName(name))
        {
            Debug.LogWarning("创建角色成功！！！！！");

            //根据角色基础属性，构建一个角色对象出来
            RoleBasicInfo roleBasic = ConfigManager.GetInstance().GetRoleBasicInfo(_view. currentType);
            if (roleBasic != null)
            {
                Player player = new Player(roleBasic, name);
                player.roleWeapon = ENUM_Weapon.Knife;
                PlayerConfig config = ConfigManager.GetInstance().GetPlayerConfig();
                if (config == null)
                {
                    config = new PlayerConfig();
                }
                config.players.Add(player);
                ConfigManager.GetInstance().SetPlayerConfig(config);
                string s = JsonConvert.SerializeObject(config);
                Debug.LogWarning(s);
                //写入本地数据表
                System.IO.File.WriteAllText(Application.dataPath + "/Resources/Config/PlayerConfig.txt", s);
            }
            else
            {
                Debug.LogError("无此职业的基础属性！！！");
            }
        }
        else
        {
            Debug.LogError("名字不合法或重复！！！");
       _view.     pop.SetActive(true);
        }
    }

    /// <summary>
    /// 检测玩家名字是否合法，且不重复
    /// </summary>
    /// <param name="name">玩家名字</param>
    /// <returns></returns>
    public bool CheckRoleName(string name)
    {
        //空白字符不合法
        if (string.IsNullOrWhiteSpace(name))
        {
            Debug.LogError("输入的是空白字符！！！");
            return false;
        }
        //判断所有玩家的名字，是否有重复
        PlayerConfig player = ConfigManager.GetInstance().GetPlayerConfig();
        if (player == null)//没玩家
        {
            return true;
        }
        for (int i = 0; i < player.players.Count; i++)
        {
            if (player.players[i].name == name)
            {
                return false;
            }
        }
        return true;
    }

    public void SwitchChooseRolePanel()
    {
        IUserInterfaceManager.GetInstance().CloseUI(typeof(CreateRoleUIConfig));
        IUserInterfaceManager.GetInstance().OpenUI(typeof(ChooseRoleUIConfig));
    }

    /// <summary>
    /// 取消
    /// </summary>
    /// <param name="theButton"></param>
    public void OnCancelBtnClick()
    {
      _view.  input.text = "";
       _view. tips.SetActive(false);
    }
}
