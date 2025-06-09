using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttackType
{
    Normal,    // 普通攻击
    Knockback, // 击退
    Launch,    // 挑空
    Freeze,
    Delay,
    // ...可扩展更多类型
}

public enum AilmentType
{
    Normal,
    Fire,
    Ice,
    Holy,
}
