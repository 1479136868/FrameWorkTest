using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvent : MonoBehaviour
{
    private PlayerParentMove playerMove;
    private Animator ani;
    private void Start()
    {
        playerMove = GetComponentInParent<PlayerParentMove>();
        ani = GetComponent<Animator>();
    }
    void AttackEnd()
    {
        playerMove.isAttack = false;
        ani.SetBool("isAttack", false);
    }

}
