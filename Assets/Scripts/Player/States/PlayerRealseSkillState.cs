using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 玩家释放技能状态，继承自PlayerState
public class PlayerRealseSkillState : PlayerState
{
    private Skill currentSkill; // 当前释放的技能

    // 构造函数，初始化释放技能状态
    public PlayerRealseSkillState(Player player, PlayerStateMachine stateMachine, string animBoolName, string animTriggerName) : base(player, stateMachine, animBoolName, animTriggerName)
    {
        
    }

    // 进入释放技能状态时调用
    public override void Enter()
    {
        base.Enter();
        PlayerSkillManager.instance.canChangeSkill = false; // 禁止切换技能
        currentSkill = PlayerSkillManager.instance.currentSkill; // 获取当前技能
        currentSkill.ReleaseSkill(); // 执行技能释放逻辑
    }

    // 退出释放技能状态时调用
    public override void Exit()
    {
        base.Exit();
        currentSkill.SkillReleaseOver(); // 技能释放结束处理
        PlayerSkillManager.instance.canChangeSkill = true; // 允许切换技能
    }

    // 逻辑更新，每帧调用
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(currentSkill.skillFinished) stateMachine.ChangeState(player.idleState); // 技能释放完成后切换到待机状态
    }

    // 物理更新，每物理帧调用
    public override void PhysicsUpdate()
    {
        currentSkill.FixedUpdate(); // 调用技能的物理更新
    }
}