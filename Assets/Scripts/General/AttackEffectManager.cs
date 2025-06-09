using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEffectManager : MonoBehaviour
{
    public static AttackEffectManager Instance { get; private set; }

    //private Attack normalAttack;

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
        BasicEffect(entity, attack);
        entity.rigidBody.AddForce(new Vector2(attack.power * attack.dir, 0), ForceMode2D.Impulse);
    }

    // 击退效果
    public void DoKnockback(Entity entity, Attack attack)
    {
        BasicEffect(entity, attack);
        entity.rigidBody.AddForce(new Vector2(attack.power * attack.dir, 0), ForceMode2D.Impulse);
    }

    // 挑空效果
    public void DoLaunch(Entity entity, Attack attack)
    {
        BasicEffect(entity, attack);
        entity.rigidBody.AddForce(new Vector2(0, attack.power * 2), ForceMode2D.Impulse);
    }

    public void DoFreeze(Entity entity, Attack attack)
    {
        BasicEffect(entity, attack);
        entity.SetZeroVelocity();
        StartCoroutine(FreezeCoroutine(entity, 0.5f));
    }

    public void DoDelay(Entity entity, Attack attack)
    {
        entity.SetZeroVelocity();

        StartCoroutine(DelayCoroutine(entity, attack, 0.2f));

    }
    private IEnumerator DelayCoroutine(Entity entity, Attack attack, float duration)
    {

        // 先静止1秒
        entity.Freeze(1f);
        yield return new WaitForSeconds(1f);

        // Attack normalAttack = new Attack(attack);
        // normalAttack.power = 1;
        // normalAttack.attackType = AttackType.Normal;
        // 再进行5次连续攻击（每次间隔duration秒）
        int times = 5;
        for (int i = 0; i < times; i++)
        {
            attack.attackType = AttackType.Normal;
            attack.power = 1;
            entity.TakeDamage(attack);
            yield return new WaitForSeconds(duration);
        }
        attack.attackType = AttackType.Delay;
    }

    // private IEnumerator LightCutCoroutine(Entity entity,Attack attack, float duration)
    // {
    //     for (int i = 0; i < 5; i++)
    //     {
    //         CameraFx.Instance.HitPause((int)attack.power * 3);
    //         CameraFx.Instance.IntenseCameraShake(0.1f, attack.power * 0.05f);
    //         PlayAnimation(entity);
    //         yield return new WaitForSeconds(duration);
    //     }
    // }


    private IEnumerator FreezeCoroutine(Entity entity, float duration)
    {

        entity.rigidBody.isKinematic = true; // 防止物理力影响

        yield return new WaitForSeconds(duration);

        entity.rigidBody.isKinematic = false;
    }


    private void Shake(Attack attack)
    {
        CameraFx.Instance.HitPause((int)attack.power * 3);
        CameraFx.Instance.CameraShake(0.1f, attack.power * 0.05f);
    }

    private void PlayAnimation(Entity entity)
    {
        entity.animator.SetTrigger("Hurt");
        entity.fxAnimator.SetTrigger("HurtTrigger"); // 播放受击特效动画
    }

    private void BasicEffect(Entity entity,Attack attack)
    {
        entity.stat.DoPhysicsDamage(attack.physicsDamage);
        entity.stat.DoMagicDamage(attack.magicDamage, attack.ailmentType);
        Shake(attack);
        PlayAnimation(entity);
    }

    // ...可扩展更多效果
}
