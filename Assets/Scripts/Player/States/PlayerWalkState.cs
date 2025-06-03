using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkState : PlayerGroundState
{
    public PlayerWalkState(Player player, PlayerStateMachine stateMachine, string animBoolName, string animTriggerName) : base(player, stateMachine, animBoolName, animTriggerName)
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
 
        if (Mathf.Abs(inputXY.x) < 0.1)        // 如果输入的X轴小于0.1，则切换到Idle状态
            stateMachine.ChangeState(player.idleState);
        else if (Mathf.Abs(inputXY.x) > 0.7)   // 如果输入的X轴大于0.7，则切换到Run状态
            stateMachine.ChangeState(player.runState);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
