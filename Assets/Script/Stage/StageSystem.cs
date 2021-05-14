using UnityEngine;
using System.Collections.Generic;
using System;

/// <summary>
/// 关卡系统
/// </summary>
public class StageSystem : IGameSystem
{
    private BattleManager GM { get { return m_GM as BattleManager; } }

    private IStageHandler m_NowStageHandler = null;

    private IStageHandler m_RootStageHandler = null;

    public int GetEnemyKilledCount()
    {
        return m_EnemyKilledCount;
    }

    private int level = 0;

    /// <summary>
    /// 攻击地点
    /// </summary>
    private Vector3 m_AttackPos = Vector3.zero;
    private int m_EnemyKilledCount;

    public StageSystem(IGameManager GM) : base(GM)
    {
        Initialize();
    }

    /// <summary>
    /// 初始化
    /// </summary>
    public override void Initialize()
    {
        InitializeStageData();
    }

    /// <summary>
    /// 初始化关卡数据
    /// </summary>
    private void InitializeStageData()
    {

    }

    /// <summary>
    /// 通过传过来的关卡初始化(单个)
    /// </summary>
    /// <param name="info"></param>
    public void InitStage(StageInfo info)
    {
        /***********建议读表i***********/
        if (m_RootStageHandler != null)
        {
            return;
        }

        NormalStageData StageData = null; // 生成的怪物的Enemy
        IStageScore StageScore = null; // 通关的成绩
        IStageHandler NewStage = null;

        ////1
        StageData = new NormalStageData(1, GetSpawnPosition());
        StageData.AddStageData(ENUM_Enemy.Keraha, 1);
        StageScore = new StageScoreEnemyKilledCount(1, this);
        NewStage = new NormalStageHandler(StageScore, StageData);

        // 设置初始关卡
        m_RootStageHandler = NewStage;

        //指定第一个关卡
        m_NowStageHandler = m_RootStageHandler;

        level = 0;
    }

    /// <summary>
    /// 通过传过来的关卡初始化(列表)
    /// </summary>
    /// <param name="info"></param>
    public void InitStage(List<StageInfo> infos)
    {
        #region
        /***********建议读表i***********/
        if (m_RootStageHandler != null)
        {
            return;
        }

        NormalStageData StageData = null; // 生成的怪物的Enemy
        IStageScore StageScore = null; // 通关的成绩
        IStageHandler NewStage = null;

        ////1
        StageData = new NormalStageData(1, GetSpawnPosition());
        StageData.AddStageData(ENUM_Enemy.Keraha, 1);
        StageScore = new StageScoreEnemyKilledCount(1, this);
        NewStage = new NormalStageHandler(StageScore, StageData);

        // 设置初始关卡
        m_RootStageHandler = NewStage;

        ////2
        //StageData = new NormalStageData(2, GetSpawnPosition(), AttackPosition);
        //StageData.AddStageData(ENUM_Enemy.Keraha, 3);
        //StageScore = new StageScoreEnemyKilledCount(6, this);
        //NewStage = NewStage.SetNextHandler(new NormalStageHandler(StageScore, StageData));


        ////3
        //StageData = new NormalStageData(3, GetSpawnPosition(), AttackPosition);
        //StageData.AddStageData(ENUM_Enemy.Keraha, 3);
        //StageScore = new StageScoreEnemyKilledCount(9, this);
        //NewStage = NewStage.SetNextHandler(new NormalStageHandler(StageScore, StageData));
        #endregion
    }

    /// <summary>
    /// 随机返回一个出生点(范围)
    /// </summary>
    /// <returns></returns>
    private Vector3 GetSpawnPosition()
    {
        return new Vector3(UnityEngine.Random.Range(-10, 10), UnityEngine.Random.Range(-5, 2), 0);

    }

    /// <summary>
    /// 找玩家攻击
    /// </summary>
    /// <returns></returns>
    private Vector3 GetAttackPosition()
    {
        return Vector3.zero;
    }

    public override void Release()
    {
        base.Release();

        GM.ClearEnemy();
    }

    public override void Update()
    {
        m_NowStageHandler.Update();

        if (BattleManager.Instance.GetEnemyCount() == 0)
        {
            if (m_NowStageHandler.IsFinished() == false)
                return;
            level++;
            if (level < 3)
            {
                IStageHandler NewStageData = m_NowStageHandler.CheckStage();

                if (m_NowStageHandler == NewStageData)
                    m_NowStageHandler.Reset();
                else
                    m_NowStageHandler = NewStageData;

                Debug.Log("当前通关波次:" + level);
                return;
            }


            NotiyfNewStage();
        }
    }

    /// <summary>
    /// 通知新的关卡
    /// </summary>
    private void NotiyfNewStage()
    {

        Debug.LogError("闯关成功！！！");

        if (!Tips.isShow)
        {
            Tips.Instance.ReSetTextContent("闯关成功！！！");
            Tips.Instance.ReSetBtnCallback(() =>
            {

                MessManager.GetInstance().SendMes("SwitchState", "MainScene");

            });
            Tips.Instance.Show();
        }
        return;




        //m_GM.ShowNowStageLv(m_NowStageLv);

        // 事件
        //m_GM.NotifyGameEvent(ENUM_GameEvent.NewStage, m_NowStageLv);
    }

    public void GetStageInfo(int v)
    {

    }
}
