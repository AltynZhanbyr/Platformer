using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float RocketSpeed;
    public float RotationSpeed;

    private Transform _playerTransfrom;

    void Start()
    {
        _playerTransfrom = FindObjectOfType<PlayerHealth>().transform;
    }

    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * RocketSpeed;
        if (transform.position.z != 0) 
        {
            transform.position = new Vector3(transform.position.x, transform.position.y,0f) ;
        }
        Vector3 delta = _playerTransfrom.position - transform.position;
        transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.LookRotation(delta,Vector3.forward),Time.deltaTime*RotationSpeed);
    }
}
