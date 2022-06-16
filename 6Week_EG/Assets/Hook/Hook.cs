using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    private FixedJoint _fixedJoint;

    public Rigidbody Rigidbody;

    public RopeGun RopeGun;

    private void OnCollisionEnter(Collision collision)
    {
        if (!_fixedJoint) 
        {
            _fixedJoint = gameObject.AddComponent<FixedJoint>();
            if (collision.rigidbody) 
            {
                _fixedJoint.connectedBody = collision.rigidbody;
            }
            RopeGun.CreateSpring();
        }
    }

    public void DestroyFix() 
    {
        if(_fixedJoint)
            Destroy(_fixedJoint);
    }
}
