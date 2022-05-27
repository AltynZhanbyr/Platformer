using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemrRotateWithEuler : MonoBehaviour
{
    public Vector3 EulerRight;
    public Vector3 EulerLeft;

    private Transform _playerTransfrom;

    private Vector3 _targetEuler;

    public float RotationSpeed;

    void Start()
    {
        _playerTransfrom = FindObjectOfType<PlayerHealth>().transform;
    }

    void Update()
    {
        if (transform.position.x > _playerTransfrom.position.x)
        {
            _targetEuler = EulerRight;
        }
        else
        {
            _targetEuler = EulerLeft;
        }
        transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.Euler(_targetEuler),Time.deltaTime*RotationSpeed);
    }
}
