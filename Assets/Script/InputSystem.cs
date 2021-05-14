using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSystem : IGameSystem
{

    private ISoldier thisSoldier = null;

    private PlayerParentMove playerTrans;

    private static InputSystem _instance;
    public static InputSystem Instance
    {
        get
        {
            if (_instance == null)
                _instance = new InputSystem(null);
            return _instance;
        }
    }

    public InputSystem(IGameManager GM) : base(GM)
    {
    }

    public override void Initialize()
    {
        base.Initialize();
    }

    public override void Release()
    {
        base.Release();
    }

    /// <summary>
    /// 输入的更新，以后还要把玩家的位移整合进去，暂时只有技能的输入
    /// </summary>
    public override void Update()
    {
        base.Update();
        if (thisSoldier != null)
        {
            if (playerTrans)
            {
                playerTrans.MoveUpdate();
                //在特定场景技能的会被检测
                if (!BattleManager.Instance.ThisGameIsOver())
                {
                    //在任何场景，玩家的移动输入是可以被检测的
                    playerTrans.PlayerSkillInput();
                }
            }
        }
    }

    public void SetSoldier(ISoldier soldier)
    {

        thisSoldier = soldier;
        playerTrans = soldier.GetGameObject().GetComponent<PlayerParentMove>();
    }
}
