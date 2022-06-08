using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun : MonoBehaviour
{
    public float BulletSpeed;
    public GameObject BulletPrefab;
    public Transform Spawn;
    public float ShootPeriod=0.2f;

    public ParticleSystem ShotSmoke;

    public AudioSource ShotSound;
    public GameObject Flash;

    private float _timer;

    void Update()
    {
        _timer+=Time.unscaledDeltaTime;
        if(_timer>ShootPeriod)
        {
            if(Input.GetMouseButton(0))
            {
                _timer=0;
                Shot();
            }
        }
    }
    public virtual void Shot() 
    {
        GameObject newBullet = Instantiate(BulletPrefab, Spawn.position, Spawn.rotation);
        newBullet.GetComponent<Rigidbody>().AddForce(transform.forward * BulletSpeed, ForceMode.VelocityChange);
        ShotSound.Play();
        Flash.SetActive(true);
        Invoke("TurnOff", 0.12f);
        ShotSmoke.Play();
    }
    private void TurnOff()
    {
        Flash.SetActive(false);
    }
    public virtual void ActivateGun() 
    {
        gameObject.SetActive(true);
    }
    public virtual void DeactivateGun()
    {
        gameObject.SetActive(false);
    }
    public virtual void AddBullets(int bulletCount) 
    {
    }
}
