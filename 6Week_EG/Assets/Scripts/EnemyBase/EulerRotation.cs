using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EulerRotation : MonoBehaviour
{

    public Vector3 LeftDirection;
    public Vector3 RightDirection;

    private Transform _playerTransfrom;

    private Vector3 _targetEuler;

    public float RotationSpeed;

    void Update()
    {
        transform.localRotation = Quaternion.Lerp(transform.localRotation,Quaternion.Euler(_targetEuler),Time.deltaTime*RotationSpeed);      
    }
    public void ToRight() 
    {
        _targetEuler = RightDirection;
    }
    public void ToLeft() 
    {
        _targetEuler = LeftDirection;
    }
}
