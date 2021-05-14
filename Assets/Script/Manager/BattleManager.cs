using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : IGameManager
{
    /// <summary>
	/// 私有构造
	/// </summary>
	private BattleManager() { }

    //------------------------------------------------------------------------
    // Singleton模版
    private static BattleManager _instance;
    public static BattleManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = new BattleManager();
            return _instance;
        }
    }

    /// <summary>
    /// 是否游戏结束
    /// </summary>
    private bool m_bGameOver = false;

    /*************************游戏系统***********************/

    /// <summary>
    /// 事件系统
    /// </summary>
    private GameEventSystem m_GameEventSystem = null;

    /// <summary>
    /// 关卡系统
    /// </summary>
    private StageSystem m_StageSystem = null; 


    /***********************UI界面****************************/

    /// <summary>
    /// 初始化
    /// </summary>
    public override void Initinal()
    {
        // 游戏状态
        m_bGameOver = false;

        m_StageSystem = new StageSystem(this);

        m_StageSystem.InitStage(MainManager.Instance.info); 

        CharacterSystem.Instance.SetGM(this);


        CharacterSystem.Instance.ShowSoldier();
        CharacterSystem.Instance.SetCameraFollow();

        IUserInterfaceManager.GetInstance().OpenUI(typeof(MainUIConfig));
    }

    /// <summary>
    /// 注册事件
    /// </summary>
    private void ResigerGameEvent()
    {

    }

    /// <summary>
    /// 释放
    /// </summary>
    public override void Release()
    {
        m_bGameOver = false;

        IUserInterfaceManager.GetInstance().CloseUI(typeof(MainUIConfig));
        IUserInterfaceManager.GetInstance().CloseUI(typeof(BagUIConfig));
        IUserInterfaceManager.GetInstance().CloseUI(typeof(BloodUIConfig));

        CharacterSystem.Instance.HideSoldier();
        //CharacterSystem.Instance.RemoveAllEnemy();
        // 遊戲系統 
        m_StageSystem.Release();
        // 界面 
        UITool.ReleaseCanvas();

    }

    /// <summary>
    ///  更新
    /// </summary>
    public override void Update()
    {
        // 玩家输入
        InputProcess();

        //游戏系统的更新  
        m_StageSystem.Update();

        CharacterSystem.Instance.Update();
    }

    /// <summary>
    /// 玩家输入
    /// </summary>
    private void InputProcess()
    {
        InputSystem.Instance.Update();
    }

    /// <summary>
    /// 获取现在的游戏状态
    /// </summary>
    /// <returns></returns>
    public bool ThisGameIsOver()
    {
        return m_bGameOver;
    }

    /// <summary>
    /// 返回主菜单
    /// 更改现在的游戏状态
    /// </summary>
    public void ChangeToMainMenu()
    {
        m_bGameOver = true;
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
    ///  增加Enemy
    /// </summary>
    /// <param name="theEnemy"></param>
    public void AddEnemy(IEnemy theEnemy)
    {
        CharacterSystem.Instance.AddEnemy(theEnemy);
    }

    public void ClearEnemy()
    {
        CharacterSystem.Instance.RemoveAllEnemy( );
    }

    /// <summary>
    /// 移除Enemy
    /// </summary>
    /// <param name="theEnemy"></param>
    public void RemoveEnemy(IEnemy theEnemy)
    {
        CharacterSystem.Instance.RemoveEnemy(theEnemy);
    }
    /// <summary>
    /// 获取当前的敌人数量
    /// </summary>
    /// <returns></returns>
    public int GetEnemyCount()
    {
        return   CharacterSystem.Instance.GetEnemyCount();
    }
}
