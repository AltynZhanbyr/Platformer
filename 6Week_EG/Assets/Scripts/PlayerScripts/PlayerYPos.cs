using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerYPos : MonoBehaviour
{
    public PlayerHealth PlayerHealth;

    public float FallTime;

    void Update()
    {
        if (transform.position.y<-20f) 
        {
            Invoke("Fallen",FallTime);
        }    
    }
    void Fallen() 
    {
        PlayerHealth.TakeDamage(1000);
    }
}
