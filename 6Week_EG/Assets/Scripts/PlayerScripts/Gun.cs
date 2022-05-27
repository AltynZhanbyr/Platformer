using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float BulletSpeed;
    public GameObject BulletPrefab;
    public Transform Spawn;
    public float ShootPeriod=0.2f;

    public AudioSource ShotSound;
    public GameObject Flash;

    private float _timer;

    void Update()
    {
        _timer+=Time.deltaTime;
        if(_timer>ShootPeriod)
        {
            if(Input.GetMouseButton(0))
            {
                _timer=0;
                GameObject newBullet=Instantiate(BulletPrefab,Spawn.position,Spawn.rotation);
                newBullet.GetComponent<Rigidbody>().AddForce(transform.forward*BulletSpeed,ForceMode.VelocityChange);
                ShotSound.Play();
                Flash.SetActive(true);
                Invoke("TurnOff",0.12f);
            }
        }
    }
    private void TurnOff()
    {
        Flash.SetActive(false);
    }
}
