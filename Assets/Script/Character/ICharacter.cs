using UnityEngine;
using System.Collections.Generic;
using System;

/// <summary>
/// 角色抽象接口
/// 拥有IWeapon对象的引用(桥接模式)
/// </summary>
public abstract class ICharacter
{
    /// <summary>
    /// 名字
    /// </summary>
    protected string m_Name = "";

    /// <summary>
    /// 游戏物体
    /// </summary>
    public GameObject m_GameObject = null;

    /// <summary>
    /// 角色Icon
    /// </summary>
    protected string m_IconSpriteName = "";

    /// <summary>
    /// 使用的武器
    /// </summary>
    protected IWeapon m_Weapon = null;

    /// <summary>
    /// 基础属性
    /// </summary>
    protected ICharacterAttr m_Attribute = null;

    /// <summary>
    /// 角色属性的编号
    /// </summary>
    protected int m_AttrID = 0;

    /// <summary>
    /// 门
    /// </summary>
    private Transform door = null;

    /// <summary>
    /// 资源名字
    /// </summary>
    protected string m_AssetName = "";

    /// <summary>
    /// 角色AI
    /// </summary>
    protected ICharacterAI m_AI = null;


    public ICharacter() { }

    /// <summary>
    /// 设置游戏物体
    /// </summary>
    /// <param name="theGameObject"></param>
    public void SetGameObject(GameObject theGameObject)
    {
        m_GameObject = theGameObject;
    }

    /// <summary>
    /// 获取游戏物体
    /// </summary>
    /// <returns></returns>
    public GameObject GetGameObject()
    {
        return m_GameObject;
        //可初始化游戏物体相关的组件
    }

    public void SetAI(EnemyAI theAI)
    {
        m_AI = theAI;
    }

    /// <summary>
    /// 获取资源名字
    /// </summary>
    /// <returns></returns>
    public string GetAssetName()
    {
        return m_AssetName;
    }

    /// <summary>
    /// 注销
    /// </summary>
    public void Release()
    {
        m_Name = null;
        m_IconSpriteName = null;
        if (m_Weapon != null)
        {
            m_Weapon.Release();
            m_Weapon = null;
        }

        door = null;
        m_AssetName = null;
        m_AI = null;

        if (m_GameObject != null)
            GameObject.Destroy(m_GameObject);
    }

    /// <summary>
    /// 获取攻击范围
    /// </summary>
    /// <returns></returns>
    public float GetAttackRange()
    {
        return m_Weapon.GetAtkRange();
    }

    public ICharacterAttr GetAttribute()
    {

        return m_Attribute;
    }

    /// <summary>
    /// 获取名字
    /// </summary>
    /// <returns></returns>
    public string GetName()
    {
        return m_Name;
    }

    internal void SetCharacterAI(ICharacterAI CharacterAI)
    {
        m_AI = CharacterAI;

    }

    /// <summary>
    /// 获取Icon图片名字
    /// </summary>
    /// <returns></returns>
    public string GetIconSpriteName()
    {
        return m_IconSpriteName;
    }

    public void UpdateAI(ICharacter targets)
    {
        m_AI.Update(targets);
    }

    /// <summary>
    /// 是否死亡
    /// </summary>
    /// <returns></returns>
    public bool IsKilled()
    {
        return m_Attribute.GetNowHP() <= 0;
    }

    /// <summary>
    /// 获取角色目前值
    /// </summary>
    /// <returns></returns>
    public ICharacterAttr GetCharacterAttr()
    {
        return m_Attribute;
    }

    /// <summary>
    /// 获取角色名称
    /// </summary>
    /// <returns></returns>
    public string GetCharacterName()
    {
        return m_Name;
    }

    // 更新
    public void Update()
    {
        //驱动武器的Update
        if (m_Weapon != null)
        {
            m_Weapon.Update();
        }

        if (door)
        {
            if (Vector3.Distance(door.position, GetPosition()) < 0.5f)
            {
                MainManager.Instance.ToSelectStage();
            }
        }
    }

    public void SetDoor(Transform door) { this.door = door; }

    /// <summary>
    /// 获取武器攻击力
    /// </summary>
    /// <returns></returns>
    public int GetAtkValue()
    {
        return m_Weapon.GetAtkValue();
    }

    /// <summary>
    /// 移动
    /// </summary>
    /// <param name="Position"></param>
    public void MoveTo(Vector3 Position)
    {

        m_GameObject.transform.position = Vector3.MoveTowards(m_GameObject.transform.position, Position, Time.deltaTime * m_Attribute.GetMoveSpeed());
        if (m_GameObject.transform.position.x < Position.x)
        {
            m_GameObject.transform.localScale = Vector3.one;
        }
        else
        {
            m_GameObject.transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    /// <summary>
    /// 停止移动
    /// </summary>
    public void StopMove()
    {

    }

    /// <summary>
    /// 获取游戏物体位置
    /// </summary>
    /// <returns></returns>
    public Vector3 GetPosition()
    {
        return m_GameObject.transform.Find("Pos").position;
    }

    /// <summary>
    /// 设置使用的武器
    /// </summary>
    /// <param name="Weapon"></param>
    public void SetWeapon(IWeapon Weapon)
    {
        if (m_Weapon != null)
            m_Weapon.Release();
        m_Weapon = Weapon;

        // 设置持有武器的对象
        m_Weapon.SetCharacter(this);

    }

    /// <summary>
    /// 获取武器
    /// </summary>
    /// <returns></returns>
    public IWeapon GetWeapon()
    {
        return m_Weapon;
    }

    /// <summary>
    /// 调用武器，来攻击目标
    /// </summary>
    /// <param name="Target"></param>
    protected void WeaponAttackTarget(ICharacter Target)
    {
        m_Weapon.Fire(Target);
    }

    /// <summary>
    /// 死亡
    /// 播放死亡动画等等逻辑
    /// </summary>
    public virtual void Killed()
    {
        Debug.LogError(GetGameObject().name+"死啦！！！");
    }

    /// <summary>
    /// 取得属性ID
    /// </summary>
    /// <returns></returns>
    public int GetAttrID()
    {
        return m_AttrID;
    }

    /// <summary>
    /// 设置角色数值
    /// </summary>
    /// <param name="CharacterAttr"></param>
    public virtual void SetCharacterAttr(ICharacterAttr attr)
    {
        m_Attribute = attr;

        m_Attribute.InitAttr();



    }

    /// <summary>
    /// 播放音效
    /// </summary>
    /// <param name="ClipName"></param>
    public void PlaySound(string ClipName)
    {
        //  取得音效
        IAssetFactory Factory = GameFactory.GetAssetFactory();
        AudioClip theClip = Factory.LoadAudioClip(ClipName);
        if (theClip == null)
            return;
    }

    /// <summary>
    /// 播放特效
    /// </summary>
    /// <param name="EffectName"></param>
    public void PlayEffect(string EffectName)
    {
        //  取得特效
        IAssetFactory Factory = GameFactory.GetAssetFactory();
        GameObject EffectObj = Factory.LoadEffect(EffectName);
        if (EffectObj == null)
            return;

        //附加到游戏物体上
        UnityTool.Attach(m_GameObject, EffectObj, Vector3.zero);
    }

    public abstract void Attack(ICharacter Target);

    public abstract void UnderAttack(ICharacter Attacker);

}




