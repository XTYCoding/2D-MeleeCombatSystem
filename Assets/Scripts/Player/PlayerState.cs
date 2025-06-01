using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerState
{
    protected PlayerStateMachine stateMachine;
    protected Player player;

    protected Rigidbody2D rigidBody;
    protected PlayerInput playerInput;
    protected Animator animator;
    protected PhysicsCheck physicsCheck;

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
        //Debug.Log("Enter"+animBoolName);
        rigidBody = player.rigidBody;
        animator = player.animator;
        playerInput = player.playerInput;
        physicsCheck = player.physicsCheck;
        animFinTrigger = false;

        player.playerInput.GamePlay.ReleaseSkill.started += ReleaseSkill;


        inputXY = playerInput.GamePlay.Move.ReadValue<Vector2>();
        if (!string.IsNullOrEmpty(animBoolName) && HasAnimatorParameter(animator, animBoolName, AnimatorControllerParameterType.Bool))
        {
            animator.SetBool(animBoolName, true);
        }

        if (!string.IsNullOrEmpty(animTriggerName) && HasAnimatorParameter(animator, animTriggerName, AnimatorControllerParameterType.Trigger))
        {
            animator.SetTrigger(animTriggerName);
        }
    }

    private void ReleaseSkill(InputAction.CallbackContext context)
    {
        if(PlayerSkillManager.instance.currentSkill != null && PlayerSkillManager.instance.currentSkill.IsSkillAvailable())
        {
            //PlayerSkillManager.instance.currentSkill.enabled = true;
            player.stateMachine.ChangeState(player.realseSkillState);
        }
        else
        {
            Debug.Log("Current skill is not available or null");
        }
    }

    public virtual void Exit()
    {
        if (!string.IsNullOrEmpty(animBoolName) && HasAnimatorParameter(animator, animBoolName, AnimatorControllerParameterType.Bool))
        {
            animator.SetBool(animBoolName, false);
        }
        //Debug.Log("Exit" + animBoolName);

        player.playerInput.GamePlay.ReleaseSkill.started -= ReleaseSkill;
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
