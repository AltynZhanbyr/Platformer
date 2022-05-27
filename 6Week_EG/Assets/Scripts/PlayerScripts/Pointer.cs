using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    public Transform Aim;
    public Camera PlayerCamera;
    public Transform Body;
    public float RotSpeed;
    public float _yEuler;
    public Vector3 Delta;

    void LateUpdate()
    {
        Ray ray=PlayerCamera.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay( ray.origin,ray.direction*50,Color.yellow);
        Plane plane=new Plane(Vector3.forward,Vector3.zero);

        float distance;
        plane.Raycast(ray,out distance);
        Vector3 point=ray.GetPoint(distance);
        Aim.position=point;
         
        Delta=Aim.position-transform.position;
        //transform.rotation=Quaternion.LookRotation(Delta);
        transform.rotation=Quaternion.Lerp(transform.rotation,Quaternion.LookRotation(Delta),Time.deltaTime*20);

        if(Delta.x<0)
        {
            _yEuler=Mathf.Lerp(_yEuler,45f,Time.deltaTime*RotSpeed);
        }
        else
        {
             _yEuler=Mathf.Lerp(_yEuler,-45f,Time.deltaTime*RotSpeed);
        }
        Body.localEulerAngles=new Vector3(0f,_yEuler,0f);
    }
}
  