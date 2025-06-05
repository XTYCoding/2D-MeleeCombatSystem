using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonStat : EnemyStat
{
    private Skeleton skeleton;

    protected override void Awake()
    {
        base.Awake(); // 调用基类的Awake方法
        skeleton = GetComponent<Skeleton>();
    }


    protected override void Dead()
    {
        base.Dead(); // 调用基类的死亡逻辑
        Debug.Log("Skeleton is dead");
        // 可以添加死亡动画或其他逻辑
        //skeleton.stateMachine.ChangeState(skeleton.deadState);

    }
}
