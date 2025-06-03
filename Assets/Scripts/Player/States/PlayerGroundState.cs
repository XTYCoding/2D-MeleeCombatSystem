using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static Unity.Collections.AllocatorManager;

// 玩家地面状态，继承自PlayerState，处理地面上的各种输入
public class PlayerGroundState : PlayerState
{
    // 构造函数，初始化地面状态
    public PlayerGroundState(Player player, PlayerStateMachine stateMachine, string animBoolName, string animTriggerName) : base(player, stateMachine, animBoolName, animTriggerName)
    {
    }

    // 进入地面状态时注册各种输入事件
    public override void Enter()
    {
        base.Enter();
        playerInput.GamePlay.Jump.started += Jump;           // 跳跃输入
        playerInput.GamePlay.Dash.started += Dash;           // 冲刺输入
        playerInput.GamePlay.BackDash.started += BackDash;   // 后撤输入
        playerInput.GamePlay.LightAttack.started += LightAttack; // 轻攻击输入
        playerInput.GamePlay.HeavyAttack.started += HeavyAttack; // 重攻击输入
        playerInput.GamePlay.Block.started += Block;         // 格挡输入
    }

    // 格挡输入回调
    private void Block(InputAction.CallbackContext context)
    {
        if(physicsCheck.isGrounded) stateMachine.ChangeState(player.blockState);
    }

    // 重攻击输入回调
    private void HeavyAttack(InputAction.CallbackContext context)
    {
        if (physicsCheck.isGrounded) stateMachine.ChangeState(player.heavyAttackState);
    }

    // 轻攻击输入回调
    private void LightAttack(InputAction.CallbackContext context)
    {
        if (physicsCheck.isGrounded)
            stateMachine.ChangeState(player.lightAttackState);
    }

    // 后撤输入回调
    private void BackDash(InputAction.CallbackContext context)
    {
        if (physicsCheck.isGrounded)
            stateMachine.ChangeState(player.backDashState);
    }

    // 冲刺输入回调
    private void Dash(InputAction.CallbackContext context)
    {
        if (physicsCheck.isGrounded)
            stateMachine.ChangeState(player.dashState);
    }

    // 跳跃输入回调
    private void Jump(InputAction.CallbackContext context)
    {
        if(physicsCheck.isGrounded)
            stateMachine.ChangeState(player.jumpState);
    }

    // 退出地面状态时注销所有输入事件
    public override void Exit()
    {
        base.Exit();
        playerInput.GamePlay.Jump.started -= Jump;
        playerInput.GamePlay.Dash.started -= Dash;
        playerInput.GamePlay.BackDash.started -= BackDash;
        playerInput.GamePlay.LightAttack.started -= LightAttack;
        playerInput.GamePlay.HeavyAttack.started -= HeavyAttack;
        playerInput.GamePlay.Block.started -= Block;
    }

    // 逻辑更新：如果不在地面则切换到下落状态
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (!physicsCheck.isGrounded) stateMachine.ChangeState(player.fallState);
    }

    // 物理更新，调用基类方法
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}