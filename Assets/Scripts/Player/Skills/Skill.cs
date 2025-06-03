using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 技能基类，所有具体技能继承自此类
public class Skill
{
    public string skillName; // 技能名称
    public bool skillFinished = false; // 技能是否释放完成
    public bool skillTrigger = false; // 技能触发标志，用在一些特殊技能中

    // 判断技能是否可用，子类可重写
    public virtual bool IsSkillAvailable()
    {
        return true;
    }

    // 释放技能的主逻辑，子类可重写
    public virtual void ReleaseSkill()
    {
        Debug.Log("Releasing skill: " + skillName);
        skillFinished = false; // 技能释放开始，标记为未完成
    }

    // 技能释放结束时调用，子类可重写
    public virtual void SkillReleaseOver()
    {
        Debug.Log("Finish skill: " + skillName);
    }

    // 使用技能（如主动触发），子类可重写
    public virtual void UseSkill()
    {
        Debug.Log("Using skill: " + skillName);
    }

    // 技能的每帧更新，子类可重写
    public virtual void Update()
    {

    }

    // 技能的物理帧更新，子类可重写
    public virtual void FixedUpdate()
    {
        
    }
}