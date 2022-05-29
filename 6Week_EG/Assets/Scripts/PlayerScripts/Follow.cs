using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    private Transform Target;
    public float FollowSpeed;

    private void Start()
    {
        Target = FindObjectOfType<PlayerHealth>().transform;
    }

    void Update()
    {
       //transform.position=Vector3.Lerp(transform.position,Target.position,Time.deltaTime*FollowSpeed); 
       transform.position=Vector3.MoveTowards(transform.position,Target.position,Time.deltaTime*FollowSpeed);
    }
}
