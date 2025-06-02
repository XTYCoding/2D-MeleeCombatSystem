using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : Entity
{

    public PlayerStateMachine stateMachine { get; private set;}

    public Vector2 inputXY;
    public int jumpForce;
    public int dashSpeed;

    public float gameSpeed;

    public int comboCounter = 0;
    public bool canAirAttack = true;

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
    public PlayerAirAttackState airAttackState { get; private set; }

    public PlayerDashAttackState dashAttackState { get; private set; }
    public PlayerBlockState blockState { get; private set; }

    public PlayerRealseSkillState realseSkillState { get; private set; }

    protected override void Awake()
    {
        // Debug.Log("Awake");
        base.Awake();
        playerInput = new PlayerInput();
        //Time.timeScale = gameSpeed;

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
        blockState = new PlayerBlockState(this, stateMachine, "Block", "BlockTrigger");
        realseSkillState = new PlayerRealseSkillState(this, stateMachine, "RealseSkill", "RealseSkillTrigger");
        dashAttackState = new PlayerDashAttackState(this, stateMachine, "DashAttack", "DashAttackTrigger");
        airAttackState = new PlayerAirAttackState(this, stateMachine, "AirAttack", "AirAttackTrigger");
    }








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
