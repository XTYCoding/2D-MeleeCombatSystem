using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill
{
    public string skillName;
    public bool skillFinished = false;
    public bool skillTrigger = false;


    public virtual bool IsSkillAvailable()
    {
        return true;
    }

    public virtual void ReleaseSkill()
    {
        Debug.Log("Releasing skill: " + skillName);
        skillFinished = false;
        
    }

    public virtual void SkillReleaseOver()
    {
        Debug.Log("Finish skill: " + skillName);
    }

    public virtual void UseSkill()
    {

        Debug.Log("Using skill: " + skillName);
    }

    public virtual void Update()
    {

    }

    public virtual void FixedUpdate()
    {
        
    }


}
