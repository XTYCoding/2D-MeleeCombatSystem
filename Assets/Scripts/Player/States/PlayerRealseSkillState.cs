using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRealseSkillState : PlayerState
{
    private Skill currentSkill;
    public PlayerRealseSkillState(Player player, PlayerStateMachine stateMachine, string animBoolName, string animTriggerName) : base(player, stateMachine, animBoolName, animTriggerName)
    {
        
    }

    public override void Enter()
    {
        base.Enter();
        PlayerSkillManager.instance.canChangeSkill = false;
        currentSkill = PlayerSkillManager.instance.currentSkill;
        currentSkill.ReleaseSkill();
    }

    public override void Exit()
    {
        base.Exit();
        currentSkill.SkillReleaseOver();
        //currentSkill.enabled = false;
        PlayerSkillManager.instance.canChangeSkill = true;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(currentSkill.skillFinished) stateMachine.ChangeState(player.idleState);
    }

    public override void PhysicsUpdate()
    {
        currentSkill.FixedUpdate();
    }
}
