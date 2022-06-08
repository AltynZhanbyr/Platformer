using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDieEffects : MonoBehaviour
{
    public ParticleSystem DieSmoke;

    public AudioSource AudioSource;

    public void DieEffect() 
    {
        Instantiate(DieSmoke,transform.position,Quaternion.identity);
        AudioSource.Play();
    }

}
