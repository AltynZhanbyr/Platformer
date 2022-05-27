 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
   public EnemyHealth Enemy;

   public bool IsDestroyable;

   private void OnCollisionEnter(Collision other) {
       if(other.gameObject.GetComponent<Bullet>())
       {
           Enemy.TakeDamage(1);
       }
       if(IsDestroyable)
       {
           Enemy.TakeDamage(5000);
       }
       
   }
}
