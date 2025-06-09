using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float physicsDamage;
    public float magicDamage;
    public float power;
    public int dir;
    public AttackType attackType;
    public AilmentType ailmentType;

    public Entity attacker;


    public Attack()
    {
        
    }

    public Attack(Attack _attack)
    {
        physicsDamage = _attack.physicsDamage;
        power = _attack.power;
        dir = _attack.dir;
        attacker = _attack.attacker;
        attackType = _attack.attackType;
    }


    public virtual void Awake()
    {
        attacker = GetComponentInParent<Entity>();

    }

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        Entity rival = collision.GetComponent<Entity>();
        dir = attacker.facingDir;
        if (rival != null)
            rival.TakeDamage(this);
        
    }
}
