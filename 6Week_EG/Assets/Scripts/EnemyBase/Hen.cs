using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hen : MonoBehaviour
{
    private  Rigidbody _rigidbody;
    private Transform _playerTransform;

    public float TimeToDistance;
    public float Speed;

    void Start()
    {
        _rigidbody=GetComponent<Rigidbody>();
        _playerTransform=FindObjectOfType<PlayerHealth>().transform;
    }

    void FixedUpdate()
    {
        //Vector3 distance=(_playerTransform.position-transform.position).normalized;
       // Vector3 force=_rigidbody.mass*(Speed*distance-_rigidbody.velocity)/TimeToDistance;
       // _rigidbody.AddForce(force);
       Vector3 distance =_playerTransform.position-transform.position;
       _rigidbody.AddForce(distance.normalized*180);
       _rigidbody.AddForce(-_rigidbody.velocity ,ForceMode.VelocityChange);
    }
}
