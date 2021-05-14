using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// 一般关卡信息
/// </summary>
public class NormalStageData : IStageData
{ 
    
    private Vector3 m_SpawnPosition;

    private List<StageData> m_StageData = new List<StageData>();

    /// <summary>
    /// 副本等级
    /// </summary>
    private int lv;

    /// <summary>
    /// 所有敌人是否都已经出生
    /// </summary>
    private bool m_AllEnemyBorn = false;

    /// <summary>
    /// 普通关卡私有的关卡数据类
    /// </summary>
    class StageData
    {
        public ENUM_Enemy emEnemy = ENUM_Enemy.Null; 
        public bool bBorn = false;
        public StageData(ENUM_Enemy emEnemy )
        {
            this.emEnemy = emEnemy; 
        }
    }

    public NormalStageData(int v, Vector3 SpawnPosition)
    {
        this.lv = v;
        this.m_SpawnPosition = SpawnPosition; 
    }

    /// <summary>
    /// 添加关卡数据
    /// </summary>
    /// <param name="emEnemy">怪物类型</param>
    /// <param name="emWeapon">武器类型</param>
    /// <param name="Count">数量</param>
    public void AddStageData(ENUM_Enemy emEnemy,  int Count)
    {
        for (int i = 0; i < Count; ++i)
            m_StageData.Add(new StageData(emEnemy ));
    }

    /// <summary>
    /// 重置
    /// </summary>
    public override void Reset()
    {
        foreach (StageData pData in m_StageData)
            pData.bBorn = false;
        m_AllEnemyBorn = false;
    }

    /// <summary>
    /// 更新
    /// </summary>
    public override void Update()
    {
        if (m_StageData.Count == 0)
            return;


        // 取得上場的角色
        StageData theNewEnemy = GetEnemy();
        if (theNewEnemy == null)
            return;

        // 工厂创建并组装好怪物
        ICharacterFactory Factory = GameFactory.GetCharacterFactory();
        Factory.CreateEnemy(theNewEnemy.emEnemy , m_SpawnPosition);

    }

    /// <summary>
    /// 获取还未生成的敌人
    /// </summary>
    /// <returns></returns>
    private StageData GetEnemy()
    {
        foreach (StageData pData in m_StageData)
        {
            if (pData.bBorn == false)
            {
                pData.bBorn = true;
                return pData;
            }
        }
        m_AllEnemyBorn = true;
        return null;
    }

    /// <summary>
    /// 是否完成
    /// 必须要重写该关卡的通关方式
    /// </summary>
    /// <returns></returns> 
    public override bool IsFinished()
    {
        return  m_AllEnemyBorn;
    }
}
