using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthLoot : MonoBehaviour
{
   public int AddHealth=1;
   private void OnTriggerEnter(Collider other) {
       if(other.attachedRigidbody.GetComponent<PlayerHealth>())
       {
           other.attachedRigidbody.GetComponent<PlayerHealth>().AddHealth(AddHealth);
           Destroy(this.gameObject);
       }
   }
}
