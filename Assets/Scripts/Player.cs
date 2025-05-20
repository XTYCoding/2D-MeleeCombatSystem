using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    public PlayerInput playerInput;
    public PhysicsCheck physicsCheck;
    public Animator animator;

    public PlayerStateMachine stateMachine { get; private set;}

    public Vector2 inputXY;
    public int moveSpeed;
    public int jumpForce;
    public bool facingRight = true;
    public int facingDir = 1; //1表示向右，-1表示向左

    public float gameSpeed;

    public int comboCounter = 0;
    public bool isAttacking;
    public PlayerIdleState idleState { get; private set; }
    public PlayerWalkState walkState { get; private set; }
    public PlayerRunState runState { get; private set; }

    public PlayerRunBreakState runBreakState { get;private set; }
    public PlayerTurnState turnState { get; private set; }
    public PlayerJumpState jumpState {  get; private set; }
    public PlayerFallState fallState { get; private set; }

    public PlayerDashState dashState { get; private set; }
    public PlayerBackDashState backDashState { get; private set; }
    public PlayerLightAttackState lightAttackState { get; private set; }
    public PlayerHeavyAttackState heavyAttackState { get; private set; }


    private void Awake()
    {
       // Debug.Log("Awake");
        rigidBody = GetComponent<Rigidbody2D>();
        physicsCheck = GetComponent<PhysicsCheck>();
        animator = GetComponentInChildren<Animator>();
        playerInput = new PlayerInput();
        Time.timeScale = gameSpeed;

        stateMachine = new PlayerStateMachine();
        idleState = new PlayerIdleState(this, stateMachine, "Idle", "IdleTrigger");
        walkState = new PlayerWalkState(this, stateMachine, "Walk", "WalkTrigger");
        runState = new PlayerRunState(this, stateMachine, "Run", "RunTrigger");
        runBreakState = new PlayerRunBreakState(this, stateMachine, "RunBreak", "RunBreakTrigger");
        turnState = new PlayerTurnState(this, stateMachine, "Turn", "TurnTrigger");
        jumpState = new PlayerJumpState(this, stateMachine, "Jump", "JumpTrigger");
        fallState = new PlayerFallState(this, stateMachine, "Fall", "FallTrigger");
        dashState = new PlayerDashState(this, stateMachine, "Dash", "DashTrigger");
        backDashState = new PlayerBackDashState(this, stateMachine, "BackDash", "BackDashTrigger");
        lightAttackState = new PlayerLightAttackState(this, stateMachine, "LightAttack", "LightAttackTrigger");
        heavyAttackState = new PlayerHeavyAttackState(this, stateMachine, "HeavyAttack", "HeavyAttackTrigger");
    }

    #region 设置速度
    public void SetVelocity(Vector2 inputXY)
    {
        FlipController(inputXY.x); //每一次改变速度都检查是否要翻转
        rigidBody.velocity = new Vector2(moveSpeed * inputXY.x * Time.deltaTime, rigidBody.velocity.y);
    }

    public void SetZeroVelocity()
    {

        rigidBody.velocity = new Vector2(0, 0);
    }
    #endregion

    #region 翻转相关
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
    #endregion






    void Start()
    {
        //Debug.Log("Start");
        stateMachine.Initialize(idleState);
        
    }

    // Update is called once per frame
    private void Update()
    {
        stateMachine.currentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        stateMachine.currentState.PhysicsUpdate();
    }

    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }
}
