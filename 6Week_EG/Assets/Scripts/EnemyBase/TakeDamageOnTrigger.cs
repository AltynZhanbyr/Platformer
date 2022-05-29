using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageOnTrigger : MonoBehaviour
{
   public EnemyHealth Enemy;
    public bool DieAnyCollision;

   private void OnTriggerEnter(Collider other) {
       if(other.GetComponent<Bullet>())
       {
           this.Enemy.TakeDamage(1);
       }
        if (DieAnyCollision) 
        {
            if(other.isTrigger==false)
                this.Enemy.TakeDamage(1000);
        }
   }
}
