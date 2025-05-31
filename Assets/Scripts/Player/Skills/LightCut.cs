using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCut : Skill
{
    public override bool IsSkillAvailable()
    {
        if(PlayerManager.instance.player.physicsCheck.isGrounded) return true;
        else return false;
     }
    public override void ReleaseSkill()
    {
        base.ReleaseSkill();
        PlayerManager.instance.player.animator.SetTrigger("LightCut");
    }
}
