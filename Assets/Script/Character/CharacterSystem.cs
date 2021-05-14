using UnityEngine;
using System.Collections.Generic;
using System;

/// <summary>
/// 角色系统
/// 管理创建出来的角色(包括自己士兵和敌人)
/// </summary>
public class CharacterSystem : IGameSystem
{ /// <summary>
  /// 私有构造
  /// </summary>
    private CharacterSystem() : base(null)
    { }

    //------------------------------------------------------------------------
    // Singleton模版
    private static CharacterSystem _instance;
    public static CharacterSystem Instance
    {
        get
        {
            if (_instance == null)
                _instance = new CharacterSystem();
            return _instance;
        }
    }

    /// <summary>
    /// 士兵
    /// </summary>
    private ICharacter m_Soldier = null;

    /// <summary>
    /// 敌人列表
    /// </summary>
    private List<ICharacter> m_Enemys = new List<ICharacter>();

    public CharacterSystem(IGameManager GM) : base(GM)
    {
        //初始化
        Initialize();

    }

    public override void Initialize()
    {
        base.Initialize();
    }

    public void SetGM(IGameManager gameManager) { m_GM = gameManager; }

    /// <summary>
    /// 设置Soldier
    /// </summary>
    /// <param name="theSoldier"></param>
    public void SetSoldier(ISoldier theSoldier)
    {
        if (m_Soldier != null)
        {
            GameObject.Destroy(m_Soldier.m_GameObject);
        }
        GameObject.DontDestroyOnLoad(theSoldier.m_GameObject);
        m_Soldier = theSoldier;


        MessManager.GetInstance().RegisterMessage("Attack", (obj) =>
        {
            theSoldier.UseSkill((obj as object[])[0] as string);

        });

    }

    public void FullSoldierNowHP()
    {
        if (m_Soldier != null)
        {
            m_Soldier.GetAttribute().FullNowHP();
        }
    }

    public void SetDoor()
    {
        if (m_Soldier != null)
        {
            m_Soldier.SetDoor(UnityTool.FindChildGameObject(UnityTool.FindGameObject("Door"), "Point").transform);
        }
    }


    /// <summary>
    /// 获取敌人数量
    /// </summary>
    /// <returns></returns>
    public int GetEnemyCount()
    {
        if (m_Enemys == null)
        {
            return 0;
        }
        return m_Enemys.Count;
    }

    /// <summary>
    /// 增加Enemy
    /// </summary>
    /// <param name="theEnemy"></param>
    public void AddEnemy(IEnemy theEnemy)
    {
        m_Enemys.Add(theEnemy);
    }

    /// <summary>
    /// 移除Enemy
    /// </summary>
    /// <param name="theEnemy"></param>
    public void RemoveEnemy(IEnemy theEnemy)
    {

        m_Enemys.Remove(theEnemy);

        Debug.Log("移除！！！"+ m_Enemys.Count);



        theEnemy.Release();
    }


    /// <summary>
    /// 更新
    /// </summary>
    public override void Update()
    {

        UpdateCharacter();
        // 更新AI
        UpdateAI();
    }
    // 更新角色
    private void UpdateCharacter()
    {
        if (m_Soldier != null)
        {
            m_Soldier.Update();
        }
        if (m_Soldier.IsKilled())
        {

            if (!Tips.isShow)
            {
                Tips.Instance.ReSetTextContent("游戏结束！！！");
                Tips.Instance.ReSetBtnCallback(() =>
                {

                    MessManager.GetInstance().SendMes("SwitchState", "MainScene");

                });
                Tips.Instance.Show();
            }
        }
    }

    // 更新AI
    private void UpdateAI()
    {
        UpdateAI(m_Enemys, m_Soldier);
    }
    // 更新AI
    private void UpdateAI(List<ICharacter> Characters, ICharacter Targets)
    {

        if (Characters != null && Characters.Count > 0)
        {
            foreach (ICharacter Character in Characters)
                Character.UpdateAI(Targets);
        }

    }

    /// <summary>
    /// 设置相机跟随
    /// </summary>
    public void SetCameraFollow()
    {
        GameObject.FindGameObjectWithTag("CM").GetComponent<Cinemachine.CinemachineVirtualCamera>().Follow = m_Soldier.GetGameObject().transform;
    }

    public void RemoveAllEnemy()
    {
        if (m_Enemys != null && m_Enemys.Count > 0)
        {
            for (int i = 0; i < m_Enemys.Count; i++)
            {
                m_Enemys[i].Release();
            }
        }
        m_Enemys.Clear();
    }

    public override void Release()
    {
        base.Release();
        m_Soldier = null;

    }

    public ISoldier GetSoldier()
    {
        return m_Soldier as ISoldier;
    }

    public void HideSoldier()
    {
        m_Soldier.m_GameObject.SetActive(false);
    }

    public void ShowSoldier()
    {
        m_Soldier.m_GameObject.SetActive(true);
        m_Soldier.m_GameObject.transform.position = Vector3.zero;
        MessManager.GetInstance().SendMes("SetMaxHpAndMp", new object[] { GetSoldier().GetCharacterAttr().GetMaxHP(), 1 });

    }

    /// <summary>
    /// 获取攻击的目标(给玩家提供的)
    /// </summary>
    /// <param name="radius">攻击半径</param>
    /// <param name="angle">攻击角度</param>
    public List<ICharacter> GetAttackTarget(int radius, int angle)
    {
        if (m_Enemys != null && m_Enemys.Count > 0)
        {
            List<ICharacter> attrs = new List<ICharacter>();
            for (int i = 0; i < m_Enemys.Count; i++)
            {
                if (Vector3.Distance(m_Enemys[i].GetPosition(), m_Soldier.GetPosition()) < radius)
                {
                    attrs.Add(m_Enemys[i] );
                }
            }
            return attrs;
        }
        return null;
    }
}
