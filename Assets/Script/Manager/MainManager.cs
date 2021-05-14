using System.Collections.Generic;
using UnityEngine;

public class MainManager : IGameManager
{
    /// <summary>
    /// 私有构造
    /// </summary>
    private MainManager() { }

    //------------------------------------------------------------------------
    // Singleton模版
    private static MainManager _instance;
    public static MainManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = new MainManager();
            return _instance;
        }
    }
     

    /*************************游戏系统***********************/

    /// <summary>
    /// 事件系统
    /// </summary>
    private GameEventSystem m_GameEventSystem = null;

    /***********************UI界面****************************/

    /// <summary>
    /// 初始化
    /// </summary>
    public override void Initinal()
    {
        // 游戏系统 
        CharacterSystem.Instance.SetGM(this);

        IUserInterfaceManager.GetInstance().OpenUI(typeof(MainUIConfig));

        // 注册游戏事件系统
        ResigerGameEvent(); 
         
        CharacterSystem.Instance.ShowSoldier();
        CharacterSystem.Instance.SetCameraFollow();
        CharacterSystem.Instance.SetDoor();
        
        //在主城会把玩家血量回复满
        CharacterSystem.Instance.FullSoldierNowHP();
    }

    public StageInfo info = null;

    /// <summary>
    /// 开始关卡(可检测是否满足进入条件)
    /// </summary>
    /// <param name="stageInfo"></param>
    public void StageBegin(StageInfo stageInfo)
    {

        info = stageInfo;
    }

    /// <summary>
    ///  更新
    /// </summary>
    public override void Update()
    {
        // 玩家输入
        InputProcess();

        //游戏系统的更新 
        CharacterSystem.Instance.Update(); 
    }

    /// <summary>
    /// 释放
    /// </summary>
    public override void Release()
    {
        CharacterSystem.Instance.HideSoldier();
        IUserInterfaceManager.GetInstance().CloseUI(typeof(MainUIConfig));
        IUserInterfaceManager.GetInstance().CloseUI(typeof(BagUIConfig));
        IUserInterfaceManager.GetInstance().CloseUI(typeof(SelectStageUIConfig));
       
        info = null;
    }

    /// <summary>
    /// 注册事件
    /// </summary>
    private void ResigerGameEvent()
    {

    }

    /// <summary>
    /// 玩家输入
    /// </summary>
    private void InputProcess()
    {
        InputSystem.Instance.Update();
    }
     
    /// <summary>
    /// 去选关
    /// </summary>
    public void ToSelectStage()
    {
        if (!IUserInterfaceManager.GetInstance().IsVisible(typeof(SelectStageUIConfig)))
        {
            IUserInterfaceManager.GetInstance().OpenUI(typeof(SelectStageUIConfig));
        }
    }

    /// <summary>
    /// 获取关卡信息
    /// </summary>
    public List<StageInfo> GetStageInfo()
    {

        return ConfigManager.GetInstance().GetStageInfo(CharacterSystem.Instance.GetSoldier().GetLv());
    }
     

    /// <summary>
    /// 注册事件
    /// </summary>
    /// <param name="emGameEvent"></param>
    /// <param name="Observer"></param>
    public void RegisterGameEvent(ENUM_GameEvent emGameEvent, IGameEventObserver Observer)
    {
        m_GameEventSystem.RegisterObserver(emGameEvent, Observer);
    }

    /// <summary>
    /// 广播
    /// </summary>
    /// <param name="emGameEvent"></param>
    /// <param name="Param"></param>
    public void NotifyGameEvent(ENUM_GameEvent emGameEvent, System.Object Param)
    {
        m_GameEventSystem.NotifySubject(emGameEvent, Param);
    }

    /// <summary>
    /// 游戏暂停
    /// </summary>
    public void GamePause()
    {
    }

    /// <summary>
    /// 获取当前的敌人数量
    /// </summary>
    /// <returns></returns>
    public int GetEnemyCount()
    {
        return CharacterSystem.Instance.GetEnemyCount();
    }
}
