using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityStat : MonoBehaviour
{
    [SerializeField] public Stat currentHP;
    [SerializeField] public Stat maxHP;


    protected virtual void Awake()
    {
        currentHP.SetValue(maxHP.GetValue());
    }

    public virtual void DoDamage(int damage)
    {
        currentHP.SetValue(currentHP.GetValue() - damage);
        if (currentHP.GetValue() <= 0)
        {
            currentHP.SetValue(0);
            Dead();
            // Handle entity death here, e.g., trigger death animation or state
        }
    }

    protected virtual void Dead() 
    {
        Debug.Log("Entity is dead");
        // Override this method in derived classes to handle specific death logic
    }

    void Start()
    {
    }
    



    
}
