using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LightCut : Skill
{
    public override bool IsSkillAvailable()
    {
        if (PlayerManager.instance.player.physicsCheck.isGrounded && PlayerSkillManager.instance.canChangeSkill) return true;
        else return false;
    }
    public override void ReleaseSkill()
    {
        base.ReleaseSkill();
        PlayerManager.instance.player.animator.SetTrigger("LightCut");
        PlayerManager.instance.player.playerInput.GamePlay.ReleaseSkill.canceled += Dash;
    }

    public override void SkillReleaseOver()
    {
        Debug.Log("Finish skill: " + skillName);
        PlayerManager.instance.player.playerInput.GamePlay.ReleaseSkill.canceled -= Dash;
    }

    private void Dash(InputAction.CallbackContext context)
    {
        PlayerManager.instance.player.animator.SetTrigger("LightCutRelease");
    }

    public override void Update()
    {

    }

    public override void FixedUpdate()
    {
        if (skillTrigger)
        {
            PlayerManager.instance.player.SetVelocity(2*PlayerManager.instance.player.facingDir * PlayerManager.instance.player.dashSpeed, 0);
        }
        else PlayerManager.instance.player.SetZeroVelocity();
    }
}
