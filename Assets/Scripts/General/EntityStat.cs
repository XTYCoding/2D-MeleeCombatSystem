using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class EntityStat : MonoBehaviour
{
    [SerializeField] public Stat currentHP;
    [SerializeField] public Stat maxHP;

    public Stat physicsArmor;
    public Stat magicArmor;
    public Stat fireResistance;
    public Stat iceResistance;
    public bool isIgnited;
    public bool isFrozen;
    public bool isWeakToHoly;

    void Update()
    {
       // Debug.Log("Update");
        if (isIgnited) Debug.Log(this.name + "is Igniting");
    }


    protected virtual void Awake()
    {
        currentHP.SetValue(maxHP.GetValue());
    }

    private float CalculatePhysicsDamage(float damage)
    {
        return damage * (1f - physicsArmor.GetValue());
    }

    private float CalculateMagicDamage(float damage)
    {
        return damage * (1f - magicArmor.GetValue());
    }

    public virtual void DoPhysicsDamage(float rawDamage)
    {
        currentHP.SetValue(currentHP.GetValue() - CalculatePhysicsDamage(rawDamage));
        if (currentHP.GetValue() <= 0)
        {
            currentHP.SetValue(0);
            Dead();
            // Handle entity death here, e.g., trigger death animation or state
        }
    }

    public virtual void DoMagicDamage(float rawDamage, AilmentType ailment)
    {
        if (isFrozen || isIgnited) return;
        switch (ailment)
        {
            case AilmentType.Fire:
                fireResistance.SetValue(fireResistance.GetValue() - CalculateMagicDamage(rawDamage));
                if (fireResistance.GetValue() <= 0)
                {
                    fireResistance.SetValue(0);
                    isIgnited = true;
                }
                break;
            case AilmentType.Ice:
                iceResistance.SetValue(iceResistance.GetValue() - CalculateMagicDamage(rawDamage));
                if (iceResistance.GetValue() <= 0)
                {
                    iceResistance.SetValue(0);
                    isFrozen = true;
                }
                break;
            case AilmentType.Holy:
                if (isWeakToHoly) DoPhysicsDamage(rawDamage);
                break;
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
