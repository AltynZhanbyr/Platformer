using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rabbit : MonoBehaviour
{
    public float AttackTime=7f;
    public Animator RabbitAnimator;
    private float _timer;
    public LayerMask layerMask;

    void Update()
    {
        Ray ray=new Ray(transform.position+new Vector3(0,1f,0),-transform.right+new Vector3(0,0,0.5f));
        Debug.DrawLine(ray.origin,ray.direction*75f,Color.red);
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit,layerMask))
        {
            if(hit.rigidbody)
            {
                if(hit.rigidbody.GetComponent<PlayerHealth>())
                {
                    RabbitAnimator.SetFloat("AttackDistance",hit.distance);   
                }
            }
        }
    }
}
