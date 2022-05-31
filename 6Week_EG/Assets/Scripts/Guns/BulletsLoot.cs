using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsLoot : MonoBehaviour
{
    public int GunID;
    public int BulletCount;

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody) 
        {
            if (other.attachedRigidbody.GetComponent<PlayerArmory>()) 
            {
                other.attachedRigidbody.GetComponent<PlayerArmory>().AddGun(GunID,BulletCount);
                Destroy(gameObject);
            }
        }
    }
}
