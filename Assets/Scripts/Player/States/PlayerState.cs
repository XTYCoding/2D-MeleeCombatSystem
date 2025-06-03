using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

// 玩家状态基类，所有具体状态继承自此类
public class PlayerState
{
    protected PlayerStateMachine stateMachine; // 状态机引用
    protected Player player; // 玩家引用

    protected Rigidbody2D rigidBody; // 玩家刚体
    protected PlayerInput playerInput; // 玩家输入
    protected Animator animator; // 玩家动画
    protected PhysicsCheck physicsCheck; // 地面检测等物理检测

    private string animBoolName; // 状态对应的动画Bool参数名
    private string animTriggerName; // 状态对应的动画Trigger参数名
    public bool animFinTrigger; // 动画完成标志

    protected Vector2 inputXY; // 当前帧输入向量

    // 构造函数，初始化状态
    public PlayerState(Player player,PlayerStateMachine stateMachine,string animBoolName, string animTriggerName)
    {
        this.player = player;
        this.stateMachine = stateMachine;
        this.animBoolName = animBoolName;
        this.animTriggerName = animTriggerName;
    }

    // 进入状态时调用
    public virtual void Enter()
    {
        //Debug.Log("Enter"+animBoolName);
        // 获取玩家组件
        rigidBody = player.rigidBody;
        animator = player.animator;
        playerInput = player.playerInput;
        physicsCheck = player.physicsCheck;
        animFinTrigger = false;


        // 刚进入时读取当前输入，防止状态切换时输入丢失
        inputXY = playerInput.GamePlay.Move.ReadValue<Vector2>();

        // 设置动画Bool参数
        if (!string.IsNullOrEmpty(animBoolName) && HasAnimatorParameter(animator, animBoolName, AnimatorControllerParameterType.Bool))
            animator.SetBool(animBoolName, true);
        // 设置动画Trigger参数
        if (!string.IsNullOrEmpty(animTriggerName) && HasAnimatorParameter(animator, animTriggerName, AnimatorControllerParameterType.Trigger))
            animator.SetTrigger(animTriggerName);
    
        // 注册技能释放输入事件
        player.playerInput.GamePlay.ReleaseSkill.started += ReleaseSkill;
    }

    // 技能释放输入事件回调
    private void ReleaseSkill(InputAction.CallbackContext context)
    {
        // 检查当前技能是否不为空且可用
        if (PlayerSkillManager.instance.currentSkill != null && PlayerSkillManager.instance.currentSkill.IsSkillAvailable())
        {
            //PlayerSkillManager.instance.currentSkill.enabled = true;
            player.stateMachine.ChangeState(player.realseSkillState);
        }
        else
        {
            Debug.Log("Current skill is not available or null");
        }
    }

    // 退出状态时调用
    public virtual void Exit()
    {
        // 关闭动画Bool参数
        if (!string.IsNullOrEmpty(animBoolName) && HasAnimatorParameter(animator, animBoolName, AnimatorControllerParameterType.Bool))
        {
            animator.SetBool(animBoolName, false);
        }
        //Debug.Log("Exit" + animBoolName);

        // 注销技能释放输入事件
        player.playerInput.GamePlay.ReleaseSkill.started -= ReleaseSkill;
    }

    // 逻辑更新，每帧调用
    public virtual void LogicUpdate()
    {
        inputXY = playerInput.GamePlay.Move.ReadValue<Vector2>();
        animator.SetBool("FacingRight", player.facingRight);
        animator.SetBool("IsGrounded", physicsCheck.isGrounded);
    }

    // 默认更新玩家速度，每物理帧调用
    public virtual void PhysicsUpdate()
    {
        player.SetVelocity(inputXY);
    }

    // 检查动画参数是否存在
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