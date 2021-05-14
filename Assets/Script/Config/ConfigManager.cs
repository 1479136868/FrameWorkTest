using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 配置表管理类
/// </summary>
public class ConfigManager : Singleton<ConfigManager>
{
    private IAssetFactory AssetFactory = GameFactory.GetAssetFactory();

    private List<RoleBasicInfo> RoleBasicInfos = new List<RoleBasicInfo>();

    private PlayerConfig playerConfig = null;

    private List<StageInfo> stageInfos = null;

    public ConfigManager()
    {
        InitRoleBasicInfoConfig();
        InitPlayerConfig();
        InitStagetConfig();
    }

    private void InitStagetConfig()
    {
        stageInfos = new List<StageInfo>();
        string s = AssetFactory.LoadConfig("Stage");
        string[] arr = s.Split('&');
        for (int i = 1; i < arr.Length; i++)
        {
            string[] array = arr[i].Split(',');
            int lv = int.Parse(array[0].Trim());
            ENUM_Enemy EnemyType = (ENUM_Enemy)int.Parse(array[1].Trim());
            int KillCount = int.Parse(array[2].Trim());
            string icon = array[3].Trim();
            string name = array[4].Trim();
            int StageType = int.Parse(array[5].Trim());
            StageInfo stage = new StageInfo(lv, EnemyType, KillCount, icon, name,StageType);
            stageInfos.Add(stage);
        }

    }

    /// <summary>
    /// 初始化玩家数据
    /// </summary>
    private void InitPlayerConfig()
    {
        string s = AssetFactory.LoadConfig("PlayerConfig");
        playerConfig = JsonConvert.DeserializeObject<PlayerConfig>(s);
    }

    /// <summary>
    /// 读取角色基础属性
    /// </summary>
    private void InitRoleBasicInfoConfig()
    {
        string s = AssetFactory.LoadConfig("RoleBasicInfoConfig");
        string[] arr = s.Split('&');
        for (int i = 1; i < arr.Length; i++)
        {
            string[] array = arr[i].Split('|');
            string name = array[0].Trim();
            string model = array[1].Trim();
            string icon = array[2].Trim();
            ENUM_Role roleType = (ENUM_Role)int.Parse(array[3].Trim());
            int wise = int.Parse(array[4].Trim());
            int power = int.Parse(array[5].Trim());
            float speed = float.Parse(array[6].Trim());
            int hp = int.Parse(array[7].Trim());
            int mp = int.Parse(array[8].Trim());
            RoleBasicInfo role = new RoleBasicInfo(name, model, icon, roleType, wise, power, speed, hp, mp);
            RoleBasicInfos.Add(role);
        }
    }

    public PlayerConfig GetPlayerConfig()
    {
        return playerConfig;
    }

    public RoleBasicInfo GetRoleBasicInfo(ENUM_Role roleType)
    {

        for (int i = 0; i < RoleBasicInfos.Count; i++)
        {
            if (RoleBasicInfos[i].roleType == roleType)
            {
                return RoleBasicInfos[i];
            }
        }
        return null;
    }


    public void SetPlayerConfig(PlayerConfig config)
    {
        playerConfig = config;
    }

    /// <summary>
    /// 获取角色基本信息配置
    /// </summary>
    /// <returns></returns>
    public List<RoleBasicInfo> GetRoleBasicInfoConfig()
    {
        return RoleBasicInfos;
    }

    /// <summary>
    /// 返回比给定等级低或等于的关卡
    /// </summary>
    /// <param name="v"></param>
    public List<StageInfo> GetStageInfo(int v)
    {
        List<StageInfo> list = new List<StageInfo>();
        for (int i = 0; i < stageInfos.Count; i++)
        {
            if (stageInfos[i].StageLv <= v)
            {
                list.Add(stageInfos[i]);
            }
        }
        return list;
    }
}
