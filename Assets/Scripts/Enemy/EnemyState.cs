using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyState
{
    protected EnemyStateMachine stateMachine;
    protected Enemy enemy;
    private string animBoolName;
    private string animTriggerName;

    protected Rigidbody2D rigidBody;
    protected Animator animator;
    protected PhysicsCheck physicsCheck;
    public bool animFinTrigger;

    public EnemyState(EnemyStateMachine stateMachine, Enemy enemy, string animBoolName, string animTriggerName)
    {
        this.stateMachine = stateMachine;
        this.enemy = enemy;
        this.animBoolName = animBoolName;
        this.animTriggerName = animTriggerName;
    }

    public virtual void Enter()
    {
        Debug.Log("Enter" + animBoolName);
        rigidBody = enemy.rigidBody;
        animator = enemy.animator;     
        physicsCheck = enemy.physicsCheck;

        if (!string.IsNullOrEmpty(animBoolName) && HasAnimatorParameter(animator, animBoolName, AnimatorControllerParameterType.Bool))
            animator.SetBool(animBoolName, true);


        if (!string.IsNullOrEmpty(animTriggerName) && HasAnimatorParameter(animator, animTriggerName, AnimatorControllerParameterType.Trigger))
            animator.SetTrigger(animTriggerName);

    }

    public virtual void Exit()
    {
        Debug.Log("Exit" + animBoolName);
        if (!string.IsNullOrEmpty(animBoolName) && HasAnimatorParameter(animator, animBoolName, AnimatorControllerParameterType.Bool))
        {
            animator.SetBool(animBoolName, false);
        }
    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void PhysicsUpdate() 
    {
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
