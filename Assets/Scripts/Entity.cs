using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    public PlayerInput playerInput;
    public PhysicsCheck physicsCheck;
    public Animator animator;
    public Animator fxAnimator;
    
    public bool isAttacking;
    public bool isBlocking;
    public bool Stunned;

    public bool facingRight = true;
    public int facingDir = 1;
    public int moveSpeed;

    public bool noFlip = false; // If true, the entity will not flip when changing direction

    protected virtual void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        physicsCheck = GetComponent<PhysicsCheck>();
        Animator[] animators = GetComponentsInChildren<Animator>();
        animator = animators[0];
        fxAnimator = animators[1];
    }

    public void FlipController(float x)
    {
        if (!noFlip)
        {
            if (x > 0.05 && !facingRight) { Flip(); }
            else if (x < -0.05 && facingRight) { Flip(); }
        }

    }

    public void Flip()
    {
        //Debug.Log("Flip");
        facingDir *= -1;
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }

    public void SetVelocity(Vector2 inputXY)
    {
       // Debug.Log("SetVelocity: " + inputXY.x + ", " + inputXY.y);
        FlipController(inputXY.x); //ÿһ�θı��ٶȶ�����Ƿ�Ҫ��ת
        rigidBody.velocity = new Vector2(moveSpeed * inputXY.x * Time.deltaTime, rigidBody.velocity.y);
    }

    public void SetVelocity(float x,float y)
    {
        //Debug.Log("SetVelocity: " + x + ", " + y);
        FlipController(x); 
        rigidBody.velocity = new Vector2(x,y);
    }

    public void SetZeroVelocity()
    {
       // Debug.Log("SetZeroVelocity");
        rigidBody.velocity = new Vector2(0, 0);
    }
    
    public virtual void TakeDamage(Attack attack)
    {
        if (isBlocking)
        {
            Debug.Log(this.name+" is Blocking");
        }
        else
        {
          //  Debug.Log(attack.power+" "+attack.dir);
            rigidBody.AddForce(new Vector2(attack.power * attack.dir, 0), ForceMode2D.Impulse);
            CameraFx.Instance.HitPause(5);
            CameraFx.Instance.CameraShake(0.1f, attack.power*0.02f);
            animator.SetTrigger("TakeDamage");
            fxAnimator.SetTrigger("TakeDamage");
            Debug.Log(this.name+"Take Damage");          
        }
        // Implement damage logic here
    }

    public void SetStunned()
    {
        Debug.Log(this.name + " Stunned");
        Stunned = true;
        CameraFx.Instance.HitPause(5);
        CameraFx.Instance.CameraShake(0.1f, 0.05f);
    }
}
