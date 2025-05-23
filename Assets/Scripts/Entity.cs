using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    public PlayerInput playerInput;
    public PhysicsCheck physicsCheck;
    public Animator animator;
    
    public bool isAttacking;
    public bool isBlocking;

    public bool facingRight = true;
    public int facingDir = 1;
    public int moveSpeed;

    protected virtual void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        physicsCheck = GetComponent<PhysicsCheck>();
        animator = GetComponentInChildren<Animator>();
    }

    public void FlipController(float x)
    {
        if (x > 0.05 && !facingRight) { Flip(); }
        else if (x < -0.05 && facingRight) { Flip(); }
;
    }

    public void Flip()
    {
        Debug.Log("Flip");
        facingDir *= -1;
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }

    public void SetVelocity(Vector2 inputXY)
    {
        FlipController(inputXY.x); //ÿһ�θı��ٶȶ�����Ƿ�Ҫ��ת
        rigidBody.velocity = new Vector2(moveSpeed * inputXY.x * Time.deltaTime, rigidBody.velocity.y);
    }

    public void SetVelocity(float x,float y)
    {
        FlipController(x); //ÿһ�θı��ٶȶ�����Ƿ�Ҫ��ת
        rigidBody.velocity = new Vector2(x,y);
    }

    public void SetZeroVelocity()
    {

        rigidBody.velocity = new Vector2(0, 0);
    }
    
    public void TakeDamage(Attack attack)
    {
        if (isBlocking)
        {
            Debug.Log(this.name+" is Blocking");
        }
        else
        {
            Debug.Log(attack.power+" "+attack.dir);
            rigidBody.AddForce(new Vector2(attack.power * attack.dir, 0), ForceMode2D.Impulse);
            animator.SetTrigger("TakeDamage");
            Debug.Log(this.name+"Take Damage");          
        }
        // Implement damage logic here
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
