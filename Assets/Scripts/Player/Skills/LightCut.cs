using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LightCut : Skill
{
    public override bool IsSkillAvailable()
    {
        // 检查玩家是否在地面上，并且可以切换技能
        if (PlayerManager.instance.player.physicsCheck.isGrounded && PlayerSkillManager.instance.canChangeSkill) return true;
        else return false;
    }

    //在Enter中调用
    public override void ReleaseSkill()
    {
        base.ReleaseSkill();
        PlayerManager.instance.player.animator.SetTrigger("LightCut");
        PlayerManager.instance.player.playerInput.GamePlay.ReleaseSkill.canceled += Dash;
    }

    //在Exit中调用
    public override void SkillReleaseOver()
    {
        Debug.Log("Finish skill: " + skillName);
        PlayerManager.instance.player.playerInput.GamePlay.ReleaseSkill.canceled -= Dash;
    }

    private void Dash(InputAction.CallbackContext context)
    {
        PlayerManager.instance.player.animator.SetTrigger("LightCutRelease");
    }

    //在LogicUpdate中调用
    public override void Update()
    {

    }

    //在PhysicsUpdate中调用
    public override void FixedUpdate()
    {
        //技能特殊事件被触发
        if (skillTrigger)
            PlayerManager.instance.player.SetVelocity(2 * PlayerManager.instance.player.facingDir * PlayerManager.instance.player.dashSpeed, 0);
        else
            PlayerManager.instance.player.SetZeroVelocity();
    }
}
