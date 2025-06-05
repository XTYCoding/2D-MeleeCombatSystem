using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Entity类是所有游戏实体的基类，包含了基本的物理属性和方法
public class Entity : MonoBehaviour
{
    #region 各种功能组件
    public Rigidbody2D rigidBody; // 角色刚体组件
    public PhysicsCheck physicsCheck; // 地面检测等物理检测组件
    public Animator animator; // 主动画控制器
    public Animator fxAnimator; // 特效动画控制器
    public EntityStat stat; // 角色状态组件（如生命值等）
    #endregion

    #region 状态变量 
    public bool isAttacking; // 是否正在攻击
    public bool isBlocking; // 是否正在格挡
    public bool Stunned; // 是否处于硬直状态
    public bool facingRight = true; // 是否面向右
    public int facingDir = 1; // 面向方向（1为右，-1为左）

    public bool noFlip = false; // 角色此时不执行Flip操作
    #endregion

    public int moveSpeed; // 移动速度

    public System.Action onFlipped;
    public System.Action takeDamage;
    protected virtual void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>(); // 获取刚体组件
        physicsCheck = GetComponent<PhysicsCheck>(); // 获取物理检测组件
        stat = GetComponent<EntityStat>(); // 获取角色状态组件
        Animator[] animators = GetComponentsInChildren<Animator>(); // 获取所有子物体上的Animator
        animator = animators[0]; // 主动画
        fxAnimator = animators[1]; // 特效动画
    }

    public void FlipController(float x)
    {
        // 根据输入方向判断是否需要翻转角色
        if (!noFlip)
        {
            if (x > 0.05 && !facingRight) { Flip(); }
            else if (x < -0.05 && facingRight) { Flip(); }
        }

    }

    public void Flip()
    {
        // 翻转角色朝向
        facingDir *= -1;
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);

        if(onFlipped != null)
            onFlipped(); // 调用翻转事件
    }

    public void SetVelocity(Vector2 inputXY)
    {
        // 设置角色速度（带方向判断和翻转）
        FlipController(inputXY.x); 
        rigidBody.velocity = new Vector2(moveSpeed * inputXY.x * Time.deltaTime, rigidBody.velocity.y);
    }

    public void SetVelocity(float x, float y)
    {
        // 设置角色速度（带方向判断和翻转）
        FlipController(x);
        rigidBody.velocity = new Vector2(x, y);
    }

    public void SetZeroVelocity()
    {
        // 速度归零
        rigidBody.velocity = new Vector2(0, 0);
    }

    public virtual void TakeDamage(Attack attack)
    {
        // 角色受伤处理
        if (isBlocking)
        {
            Debug.Log(this.name + " is Blocking");
        }
        else
        {
            TakeDamageStat(attack);
            TakeDamageEffect(attack);
            takeDamage();
            Debug.Log(this.name + "Take Damage");
        }
        // Implement damage logic here
    }

    public virtual void TakeDamageStat(Attack attack)
    {
        stat.DoDamage(attack.damage);
    }

    public virtual void TakeDamageEffect(Attack attack)
    {
        CameraFx.Instance.HitPause((int)attack.power * 3);
        CameraFx.Instance.CameraShake(0.1f, attack.power * 0.05f);
        fxAnimator.SetTrigger("HurtTrigger"); // 播放受击特效动画
        switch (attack.attackType)
        {
            case AttackType.Normal:
                AttackEffectManager.Instance.DoNormal(this, attack);
                break;
            case AttackType.Knockback:
                AttackEffectManager.Instance.DoKnockback(this, attack);
                break;
            case AttackType.Launch:
                AttackEffectManager.Instance.DoLaunch(this, attack);
                break;
                // ...更多类型
        }
        
    }

    public void SetStunned()
    {
        // 设置角色进入硬直状态
        Debug.Log(this.name + " Stunned");
        Stunned = true;
        CameraFx.Instance.HitPause(15);
        CameraFx.Instance.CameraShake(0.1f, 0.05f);
    }
}