using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallState : PlayerAirState
{
    public PlayerFallState(Player player, PlayerStateMachine stateMachine, string animBoolName, string animTriggerName) : base(player, stateMachine, animBoolName, animTriggerName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
        
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        //落地切换状态
        if (physicsCheck.isGrounded)
        {
            if (inputXY.x > 0.1) stateMachine.ChangeState(player.runState); //落地时x轴有输入就进入Run状态
            else stateMachine.ChangeState(player.idleState); //没有输入就进入Idle状态
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
