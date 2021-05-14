using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierGJS : ISoldier
{
    public SoldierGJS()
    {
        m_emSoldier = ENUM_Role.鬼剑士;
        m_AssetName = "鬼剑士";
        m_AttrID = 1;
        m_IconSpriteName = "鬼剑士";
    }


    /// <summary>
    /// 死亡的声音
    /// </summary>
    public override void DoPlayKilledSound()
    {

    }

    /// <summary>
    /// 死亡的特效
    /// </summary>
    public override void DoShowKilledEffect()
    {

    }


    public override void UseSkill(string v)
    {
        base.UseSkill(v);


        Debug.LogWarning("使用技能" + v);
        //先根据传过来的字段判断是哪个技能
        //再去取对应角色的配置表
        //根据技能的配置来找符合条件的被击怪物

        //P级阵地是根据AI找的目标，玩家没有AI，只能用技能的特性，自己筛选符合条件的敌人

        List<ICharacter> 　characters = CharacterSystem.Instance.GetAttackTarget(5, 180);
        if (characters != null)
        {
            Debug.LogWarning("当前目标："+ characters.Count+"个\t\t^^^^^^^^^^^^^" );
            if (characters.Count>0)
            {
                IUserInterfaceManager.GetInstance().OpenUI(typeof(BloodUIConfig));
            }
            else
            {
                IUserInterfaceManager.GetInstance().CloseUI(typeof(BloodUIConfig));
            }
            //血条系统显示最后一个被打的敌人就行了
            for (int i = 0; i < characters.Count; i++)
            {
                characters[i].UnderAttack(this);
                MessManager.GetInstance().SendMes("SetCurrentEnemy", characters[i].GetAttribute() as EnemyAttr);
            }

        }
        else
        {
            Debug.LogWarning("当前没有可攻击的目标！！！！！");
        }


    }
}
