using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    public int Health;

    public UnityEvent EnemyOnDamageEvent;
    public UnityEvent EnemyOnDieEvent;
    
    public void TakeDamage(int damage)
    {
        Health-=damage;
        EnemyOnDamageEvent.Invoke(); 
        if(Health<=0)
        {
            Die();
        } 
        //EnemyOnDamageEvent.Invoke(); 
    }
    private void Die()
    {
         EnemyOnDieEvent.Invoke();       
         Destroy(this.gameObject);
    }
}
