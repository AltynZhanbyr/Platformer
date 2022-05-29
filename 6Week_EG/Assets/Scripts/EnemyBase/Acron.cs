using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acron : MonoBehaviour
{
    public Vector3 Velocity;

    public float RotateSpeed;

    void Start()
    {
        transform.GetComponent<Rigidbody>().AddRelativeForce(Velocity,ForceMode.VelocityChange);
        transform.GetComponent<Rigidbody>().angularVelocity = new Vector3(
                Random.Range(-RotateSpeed,RotateSpeed)
                ,Random.Range(-RotateSpeed, RotateSpeed)
                ,Random.Range(-RotateSpeed, RotateSpeed));
    }

   
}
