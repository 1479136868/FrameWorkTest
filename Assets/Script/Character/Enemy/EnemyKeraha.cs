using UnityEngine;
using System.Collections;

/// <summary>
/// 冰女Keraha
/// </summary>
public class EnemyKeraha : IEnemy
{
	//TODO  类名需要修改，不要无意义
	public EnemyKeraha()
	{
		m_emEnemyType = ENUM_Enemy.Keraha;
		m_AssetName = "Keraha";
		m_AttrID =1;
		m_IconSpriteName = "OgreIcon";

		

	}

	// 播放音效
	public override void DoPlayHitSound()
	{
		//Debug.Log ("EnemyTroll.PlayHitSound");
	}

	// 播放特效
	public override void DoShowHitEffect()
	{
		PlayEffect("TrollHitEffect");
	}

    public override void Attack(ICharacter Target)
    {
        base.Attack(Target);

	


	}

    public override void Killed()
    {
        base.Killed();

		GetGameObject().GetComponent<Animator>().SetTrigger("Die");
    }
}
