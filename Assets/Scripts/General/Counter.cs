using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        Entity rival = collision.GetComponentInParent<Entity>();
        Debug.Log("Counter");
        if (rival != null)
        {
            rival.SetStunned();
        }
        
    }
}
