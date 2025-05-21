using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAniEvent : MonoBehaviour
{
    private Enemy enemy;
    private void Awake()
    {
        enemy = GetComponentInParent<Enemy>();
    }

    public void AnimationFinTrigger()
    {
        enemy.stateMachine.currentState.animFinTrigger = true;
    }

    public void AnimationFlip()
    {
        enemy.Flip();
    }

    // public void AnimationAttack()
    // {
    //     player.isAttacking = true;
    // }
    // public void AnimationAttackOver()
    // {
    //     player.isAttacking = false;

    // }
}
