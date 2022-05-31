using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArmory : MonoBehaviour
{
    public Gun[] Guns;

    public int CurrentGunID;

    public AudioSource GunLoot;

    void Start()
    {
        TakeGunByIndex(CurrentGunID);
    }

    public void TakeGunByIndex(int gunIndex) 
    {
        CurrentGunID = gunIndex;
        for (int i=0; i<Guns.Length;i++) 
        {
            if (i == gunIndex)
            {
                Guns[i].ActivateGun();
            }
            else 
            {
                Guns[i].DeactivateGun();
            }
        }
    }
    public void AddGun(int gunIndex,int bulletCount) 
    {
        Guns[gunIndex].AddBullets(bulletCount);
        TakeGunByIndex(gunIndex);
        GunLoot.Play();
    }
}
