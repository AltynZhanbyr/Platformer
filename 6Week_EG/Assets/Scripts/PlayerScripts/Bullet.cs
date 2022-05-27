using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject BulletParticle;

    void Start()
    {
        Destroy(gameObject,4f);
    }

    private void OnCollisionEnter(Collision other) {
        Destroy(gameObject);
        Instantiate(BulletParticle,transform.position,transform.rotation);
    }
}
