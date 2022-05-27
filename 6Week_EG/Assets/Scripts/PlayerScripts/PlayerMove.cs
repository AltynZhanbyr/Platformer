using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody PlayerRigidbody;
    public float MoveSpeed;
    public float JumpForce;
    public Transform ColliderTransform;
    public float Friction;
    public bool Grounded;
    public float SpeedMultiply;
    public float MaxSpeed;

    private void FixedUpdate() 
    {
        SpeedMultiply=1f;
        float xAxis=Input.GetAxis("Horizontal");
        if(!Grounded==true)
        {
            SpeedMultiply=0.08f;
            if(Mathf.Abs(PlayerRigidbody.velocity.x)>MaxSpeed && Mathf.Abs(xAxis)>0)
            {
                SpeedMultiply=0f;
            }
        }
        PlayerRigidbody.AddForce(xAxis*MoveSpeed*SpeedMultiply,0f,0f,ForceMode.VelocityChange);
        if(Grounded)
            PlayerRigidbody.AddForce(-PlayerRigidbody.velocity.x*Friction,0,0,ForceMode.VelocityChange);    
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(Grounded)
                PlayerRigidbody.AddForce(0f,JumpForce,0f,ForceMode.VelocityChange);
        }
        if(Input.GetKey(KeyCode.LeftControl) ||Input.GetKey(KeyCode.Space))
        {
            ColliderTransform.localScale=Vector3.Lerp(ColliderTransform.localScale,new Vector3(1f,0.65f,1f),Time.deltaTime*15f);
        }
        else
        {
            ColliderTransform.localScale=Vector3.Lerp(ColliderTransform.localScale,new Vector3(1f,1f,1f),Time.deltaTime*15f);
        }
    }
    private void OnCollisionStay(Collision other) 
    {
        for(int i=0;i<other.contactCount;i++)
        {
            float angle=Vector3.Angle(other.contacts[i].normal,Vector3.up);
            if(angle<45f)
            {
                Grounded=true; 
            }
        }
    }
    private void OnCollisionExit(Collision other) 
    {
        Grounded=false;
    }
}
