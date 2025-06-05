using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEffectManager : MonoBehaviour
{
    public static AttackEffectManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;
    }

    // 普通攻击效果
    public void DoNormal(Entity entity, Attack attack)
    {
        // 例如：播放受击动画
        entity.rigidBody.AddForce(new Vector2(attack.power * attack.dir, 0), ForceMode2D.Impulse);
    }

    // 击退效果
    public void DoKnockback(Entity entity, Attack attack)
    {
        entity.rigidBody.AddForce(new Vector2(attack.power * attack.dir, 0), ForceMode2D.Impulse);
    }

    // 挑空效果
    public void DoLaunch(Entity entity, Attack attack)
    {
        entity.rigidBody.AddForce(new Vector2(0, attack.power*2), ForceMode2D.Impulse);
    }

    // ...可扩展更多效果
}
