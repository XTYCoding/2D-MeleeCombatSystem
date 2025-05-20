using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    public PlayerInput playerInput;
    public PhysicsCheck physicsCheck;
    public Animator animator;
    

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
        FlipController(inputXY.x); //每一次改变速度都检查是否要翻转
        rigidBody.velocity = new Vector2(moveSpeed * inputXY.x * Time.deltaTime, rigidBody.velocity.y);
    }

    public void SetVelocity(float x,float y)
    {
        FlipController(x); //每一次改变速度都检查是否要翻转
        rigidBody.velocity = new Vector2(x,y);
    }

    public void SetZeroVelocity()
    {

        rigidBody.velocity = new Vector2(0, 0);
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
