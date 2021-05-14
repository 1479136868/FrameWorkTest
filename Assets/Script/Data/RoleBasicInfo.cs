/// <summary>
/// 角色基本信息类
/// </summary>
public class RoleBasicInfo
{
    public string name;
    public string model;
    public string icon;
    public ENUM_Role roleType;
    public int wise;
    public int power;
    public float speed;
    public int hp;
    public int mp;

    public RoleBasicInfo(string name, string model, string icon, ENUM_Role roleType, int wise, int power, float speed, int hp, int mp)
    {
        this.name = name;
        this.model = model;
        this.icon = icon;
        this.roleType = roleType;
        this.wise = wise;
        this.power = power;
        this.speed = speed;
        this.hp = hp;
        this.mp = mp;
    }
}
