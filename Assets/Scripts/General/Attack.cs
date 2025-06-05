using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public int damage;
    public float power;
    public int dir;
    public AttackType attackType;

    public Entity attacker;

    public virtual void Awake()
    {
        attacker = GetComponentInParent<Entity>();
        
    }

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        Entity rival = collision.GetComponent<Entity>();
        dir = attacker.facingDir;
        if (rival != null)
            {
                rival.TakeDamage(this);
            }
        
    }
}
