using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 玩家冲刺攻击状态，继承自PlayerState
public class PlayerDashAttackState : PlayerState
{
    // 构造函数，初始化冲刺攻击状态
    public PlayerDashAttackState(Player player, PlayerStateMachine stateMachine, string animBoolName, string animTriggerName) : base(player, stateMachine, animBoolName, animTriggerName)
    {
    }

    // 进入冲刺攻击状态时调用
    public override void Enter()
    {
        base.Enter();
        player.SetZeroVelocity(); 
    }

    // 退出冲刺攻击状态时调用
    public override void Exit()
    {
        base.Exit();
         // 冲刺攻击结束后速度归零
    }

    // 逻辑更新，每帧调用
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (animFinTrigger) stateMachine.ChangeState(player.idleState); // 动画完成后切换到待机状态
    }

    // 物理更新，每物理帧调用
    public override void PhysicsUpdate()
    {
        player.SetZeroVelocity(); // 冲刺攻击不需要额外物理更新，Enter中已设置速度
    }
}