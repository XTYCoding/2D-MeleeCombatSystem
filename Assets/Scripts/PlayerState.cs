using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerState
{
    protected PlayerStateMachine stateMachine;
    protected Player player;

    protected Rigidbody2D rigidBody;
    protected PlayerInput playerInput;
    protected Animator animator;

    private string animBoolName;
    private string animTriggerName;

    protected Vector2 inputXY;

    public bool animFinTrigger;


    public PlayerState(Player player,PlayerStateMachine stateMachine,string animBoolName, string animTriggerName)
    {
        this.player = player;
        this.stateMachine = stateMachine;
        this.animBoolName = animBoolName;
        this.animTriggerName = animTriggerName;
    }

    public virtual void Enter()
    {
        Debug.Log("Enter"+animBoolName);
        rigidBody = player.rigidBody;
        animator = player.animator;
        playerInput = player.playerInput;
        animFinTrigger = false;


        inputXY = playerInput.GamePlay.Move.ReadValue<Vector2>();
        if (!string.IsNullOrEmpty(animBoolName) && HasAnimatorParameter(animator, animBoolName, AnimatorControllerParameterType.Bool))
        {
            animator.SetBool(animBoolName, true);
        }

        // ¼ì²é animTriggerName ÊÇ·ñ´æÔÚ
        if (!string.IsNullOrEmpty(animTriggerName) && HasAnimatorParameter(animator, animTriggerName, AnimatorControllerParameterType.Trigger))
        {
            animator.SetTrigger(animTriggerName);
        }
    }


    public virtual void Exit()
    {
        if (!string.IsNullOrEmpty(animBoolName) && HasAnimatorParameter(animator, animBoolName, AnimatorControllerParameterType.Bool))
        {
            animator.SetBool(animBoolName, false);
        }
        Debug.Log("Exit" + animBoolName);
    }
    public virtual void LogicUpdate()
    {
        inputXY = playerInput.GamePlay.Move.ReadValue<Vector2>();
        animator.SetBool("FacingRight", player.facingRight);
        

    }
    public virtual void PhysicsUpdate()
    {
        player.SetVelocity(inputXY);
    }
    private bool HasAnimatorParameter(Animator animator, string paramName, AnimatorControllerParameterType type)
    {
        foreach (var param in animator.parameters)
        {
            if (param.name == paramName && param.type == type)
                return true;
        }
        return false;
    }
}
