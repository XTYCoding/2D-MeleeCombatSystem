using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private Player player;
    private void Awake()
    {
        player = GetComponentInParent<Player>();
    }

    public void AnimationTrigger()
    {
        player.stateMachine.currentState.animFinTrigger = true;
    }

    public void AnimationFlip()
    {
        player.Flip();
    }

    public void AnimationAttack()
    {
        player.isAttacking = true;
    }
    public void AnimationAttackOver()
    {
        player.isAttacking = false;

    }

}
