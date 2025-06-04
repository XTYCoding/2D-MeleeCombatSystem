using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public int damage;
    public float power;
    public int dir;

    private Entity attacker;

    void Awake()
    {
        attacker = GetComponentInParent<Entity>();
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Entity rival = collision.GetComponent<Entity>();
        dir = attacker.facingDir;
        if (rival != null)
            {
                rival.TakeDamage(this);
            }
        
    }
}
