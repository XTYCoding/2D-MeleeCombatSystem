using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolySlash : Skill
{
    public override bool IsSkillAvailable()
    {
        if (PlayerManager.instance.player.physicsCheck.isGrounded && PlayerSkillManager.instance.canChangeSkill) return true;
        else return false;
    }
    public override void ReleaseSkill()
    {
        base.ReleaseSkill();
        PlayerManager.instance.player.animator.SetTrigger("HolySlash");
    }
}
