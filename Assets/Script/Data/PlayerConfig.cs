using System.Collections.Generic;

public class PlayerConfig
{
    public List<Player> players = new List<Player>();
}

public class Player
{
    /// <summary>
    /// 角色名字
    /// </summary>
    public string name = string.Empty;

    /// <summary>
    /// 职业
    /// </summary>
    public ENUM_Role roleType;

    /// <summary>
    /// 角色武器
    /// </summary>
    public ENUM_Weapon roleWeapon;

    /// <summary>
    /// 血量
    /// </summary>
    public int hp;

    /// <summary>
    /// 蓝量
    /// </summary>
    public int mp;

    /// <summary>
    /// 速度
    /// </summary>
    public float speed;

    /// <summary>
    /// 等级
    /// </summary>
    public int level;

    /// <summary>
    /// 经验
    /// </summary>
    public int exp;

    /// <summary>
    /// 角色头像
    /// </summary>
    public string icon;

    /// <summary>
    /// 角色模型
    /// </summary>
    public string model;

    /// <summary>
    /// 智力
    /// </summary>
    public int wise;

    /// <summary>
    /// 力量
    /// </summary>
    public int power;

    public Player(RoleBasicInfo basicInfo, string name)
    {
        this.name = name;
        this.roleType = basicInfo.roleType;
        this.hp = basicInfo.hp;
        this.mp = basicInfo.mp;
        this.speed = basicInfo.speed;
        this.level = 1;
        this.exp = 0;
        this.icon = basicInfo.icon;
        this.model = basicInfo.model;
        this.wise = basicInfo.wise;
        this.power = basicInfo.power;
    }
    public Player()
    {

    }
}