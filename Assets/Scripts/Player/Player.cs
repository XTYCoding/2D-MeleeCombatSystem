using System.Collections;
// 引用集合类
using System.Collections.Generic;
// JetBrains 注解（可选）
using JetBrains.Annotations;
// Unity 引擎核心命名空间
using UnityEngine;
// 新输入系统命名空间
using UnityEngine.InputSystem;

// Player类，继承自Entity，表示玩家角色
public class Player : Entity
{
    // 玩家输入组件
    public PlayerInput playerInput;
    // 玩家状态机
    public PlayerStateMachine stateMachine { get; private set;}

    // 跳跃力度
    public int jumpForce;
    // 冲刺速度
    public int dashSpeed;

    // 游戏速度（可用于调节Time.timeScale）
    public float gameSpeed;

    // 连击计数器
    public int comboCounter = 0;
    // 是否可以空中攻击
    public bool canAirAttack = true;

    #region 各种状态对象，私有set防止外部修改  
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
    public PlayerFallAttackState fallAttackState{ get; private set; }
    public PlayerDashAttackState dashAttackState { get; private set; }
    public PlayerBlockState blockState { get; private set; }
    public PlayerRealseSkillState realseSkillState { get; private set; }
    
    public PlayerHurtState hurtState { get; private set; }
    #endregion

    // 初始化各状态和输入系统
    protected override void Awake()
    {
        base.Awake();
        playerInput = new PlayerInput();
        //Time.timeScale = gameSpeed;

        #region 初始化状态机和状态
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
        fallAttackState = new PlayerFallAttackState(this, stateMachine, "FallAttack", "FallAttackTrigger");
        hurtState = new PlayerHurtState(this, stateMachine, "Hurt", "HurtTrigger");
       
        #endregion
    }

    // MonoBehaviour生命周期：Start，在Awake后调用
    void Start()
    {
        //状态机初始默认状态是Idle
        stateMachine.Initialize(idleState);
    }

    public override void TakeDamage(Attack attack)
    {
        base.TakeDamage(attack);

        
    }

    // MonoBehaviour生命周期：Update，每帧调用一次
    private void Update()
    {
        stateMachine.currentState.LogicUpdate();
    }

    // MonoBehaviour生命周期：FixedUpdate，每物理帧调用一次
    private void FixedUpdate()
    {
        stateMachine.currentState.PhysicsUpdate();
    }

    // 启用时启用输入系统
    private void OnEnable()
    {
        playerInput.Enable();
    }

    // 禁用时禁用输入系统
    private void OnDisable()
    {
        playerInput.Disable();
    }
}