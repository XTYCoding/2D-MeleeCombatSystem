using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiledCast : Skill
{
    public override void ReleaseSkill()
    {
        base.ReleaseSkill();
        PlayerManager.instance.player.animator.SetTrigger("ShiledCast");
    }
}
