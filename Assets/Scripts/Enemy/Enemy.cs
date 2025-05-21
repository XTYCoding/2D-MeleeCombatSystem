using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    public EnemyStateMachine stateMachine;
    public Transform player{ get; private set; }


    protected override void Awake()
    {
        base.Awake();
        stateMachine = new EnemyStateMachine();
        player = GameObject.FindWithTag("Player").transform;

    }
    // Start is called before the first frame update
    protected virtual void Start()
    {
        //stateMachine.Initialize();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        stateMachine.currentState.LogicUpdate();
    }

    protected virtual void FixedUpdate()
    {
        stateMachine.currentState.PhysicsUpdate();
    }


}
