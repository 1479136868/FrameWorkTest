using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;


// 武器介面
/// <summary>
/// 桥接模式
/// </summary>
public abstract class IWeapon
{
    /// <summary>
    /// 武器类型
    /// </summary>
    protected ENUM_Weapon m_emWeaponType = ENUM_Weapon.Null;

    /// <summary>
    /// 享元的字段
    /// </summary>
    protected WeaponAttr m_WeaponAttr = null;

    /// <summary>
    /// 游戏物体
    /// </summary>
    protected SpriteRenderer m_GameObject = null;

    /// <summary>
    /// 持有武器的对象
    /// </summary>
    protected ICharacter m_WeaponOwner = null;
     
    /// <summary>
    /// 声音组件
    /// </summary>
    protected AudioSource m_Audio;

    public IWeapon() { }

    /// <summary>
    /// 缓存数据
    /// </summary>
    /// <param name="renderer"></param>
    public void SetIWeapon(Sprite renderer)
    {
        //武器挂点
        sprite = renderer;
    }

    private Sprite sprite = null;

    /// <summary>
    /// 展示武器
    /// </summary>
    public void ShowWeapon()
    {
        m_GameObject.sprite = sprite;
    }


    /// <summary>
    /// 获取武器类型
    /// </summary>
    /// <returns></returns>
    public ENUM_Weapon GetWeaponType()
    {
        return m_emWeaponType;
    }

    /// <summary>
    /// 设置拿武器的游戏物体
    /// </summary>
    /// <param name="theGameObject"></param>
    public void SetGameObject(SpriteRenderer theGameObject)
    {
        m_GameObject = theGameObject;

        //初始化组件
        InitComponent();
    }

    /// <summary>
    /// 返回游戏的对象
    /// </summary>
    /// <returns></returns>
    public SpriteRenderer GetGameObject()
    {
        return m_GameObject;
    }

    /// <summary>
    /// 设置持有武器的对象
    /// </summary>
    /// <param name="Owner"></param>
    public void SetCharacter(ICharacter Owner)
    {
        m_WeaponOwner = Owner;
         
    }

    /// <summary>
    /// 设置武器属性
    /// </summary>
    /// <param name="theWeaponAttr"></param>
    public void SetWeaponAttr(WeaponAttr theWeaponAttr)
    {
        m_WeaponAttr = theWeaponAttr;
    }

    /// <summary>
    /// 释放
    /// </summary>
    public void Release()
    {
        m_Audio = null;


        if (m_GameObject != null)
            GameObject.Destroy(m_GameObject);
    }

    // 更新
    public void Update()
    {

    }

    /// <summary>
    /// 初始化组件
    /// </summary>
    protected void InitComponent()
    {
        //找特效挂载点

    }
     

    /// <summary>
    /// 获取攻击力
    /// </summary>
    /// <returns></returns>
    public int GetAtkValue()
    {
        return m_WeaponAttr.Atk;
    }

    /// <summary>
    /// 获取攻击范围
    /// </summary>
    /// <returns></returns>
    public float GetAtkRange()
    {
        return m_WeaponAttr.AtkRange;
    }
     

    /// <summary>
    /// 播放音效
    /// </summary>
    /// <param name="ClipName"></param>
    public void ShowSoundEffect(string ClipName)
    {
        if (m_Audio == null)
            return;

        //使用工厂取得音效
        IAssetFactory Factory = GameFactory.GetAssetFactory();
        AudioClip theClip = Factory.LoadAudioClip(ClipName);
        if (theClip == null)
            return;
        m_Audio.clip = theClip;
        m_Audio.Play();
    }

    /// <summary>
    /// 开火攻击方法
    /// </summary>
    /// <param name="theTarget"></param>
    public void Fire(ICharacter theTarget)
    { 

        //子类实现      战斗特效显示
        DoShowBulletEffect(theTarget);

        //子类实现      声音
        DoShowSoundEffect();

        //直接命中      调用目标的被命中方法
        theTarget.UnderAttack(m_WeaponOwner);
    }

    protected abstract void DoShowBulletEffect(ICharacter theTarget);

    protected abstract void DoShowSoundEffect();
}

