public class StageInfo  
{
    /// <summary>
    /// 副本等级
    /// </summary>
    public int StageLv;

    /// <summary>
    /// 怪物类型
    /// </summary>
    public ENUM_Enemy EnemyType;

    /// <summary>
    /// 击杀数量
    /// </summary>
    public int KillCount;

    /// <summary>
    /// 副本Icon图片
    /// </summary>
    public string Icon;

    /// <summary>
    /// 副本Icon图片
    /// </summary>
    public string Name;

    /// <summary>
    /// 副本通关类型
    /// </summary>
    public int StageType;

    public StageInfo(int stageLv, ENUM_Enemy enemyType, int killCount, string icon, string name, int stageType)
    {
        StageLv = stageLv;
        EnemyType = enemyType;
        KillCount = killCount;
        Icon = icon;
        Name = name;
        StageType = stageType;
    }
}
