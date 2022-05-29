    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : MonoBehaviour
{
    private Transform _playerTransform;
    private Rigidbody _rigidbody;

    public float Speed;

    void Start()
    {
        _playerTransform=FindObjectOfType<PlayerHealth>().transform;
        _rigidbody=GetComponent<Rigidbody>();
        Vector3 delta=(_playerTransform.position-transform.position).normalized;
        _rigidbody.velocity=delta*Speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
