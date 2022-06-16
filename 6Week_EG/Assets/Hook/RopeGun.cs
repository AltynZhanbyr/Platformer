using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RopeState 
{
    Active,
    Disabled,
    Fly
}

public class RopeGun : MonoBehaviour
{
    public Transform Spawn;
    public Hook Hook;
    public float Speed;

    public PlayerMove PlayerMove;

    public Collider PlayerCollider;
    public Collider Collider;

    [Header("SpringJoint")]
    public SpringJoint SpringJoint;
    public float MaxDistance;
    public float SpringValue;
    public float Damper;
    private float _length;
    public Transform RopeStart;

    private float distance;

    public RopeState RopeState;

    private void Update()
    {

        if (Input.GetMouseButtonDown(2)) 
        {
            Shot();
        }
        if (RopeState == RopeState.Fly) 
        {
            distance = Vector3.Distance(Hook.transform.position, RopeStart.position);
            if (distance > 20f) 
            {
                Hook.gameObject.SetActive(false);
                RopeState = RopeState.Disabled;
            }
        }
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            if (RopeState == RopeState.Active) 
            {
                if (PlayerMove.Grounded == false) 
                {
                    PlayerMove.Jump();  
                }
                DestroySpring();
            }
        }
    }
    private void FixedUpdate()
    {
        if (RopeState == RopeState.Active)
        {
            PlayerMove.StopRotation();
        }
    }
    private void Shot() 
    {
        if (SpringJoint)
            Destroy(SpringJoint);
        Hook.DestroyFix();
        Hook.transform.position = Spawn.position;
        Hook.transform.rotation = Spawn.rotation;
        Hook.Rigidbody.velocity=Spawn.forward*Speed;
        Hook.gameObject.SetActive(true);
        RopeState = RopeState.Fly;
    }
    private void Start()
    {
        Physics.IgnoreCollision(Collider,PlayerCollider);
    }
    public void CreateSpring() 
    {
        if (!SpringJoint) 
        {
            SpringJoint = gameObject.AddComponent<SpringJoint>();
            SpringJoint.connectedBody = Hook.Rigidbody;
            SpringJoint.autoConfigureConnectedAnchor = false;
            SpringJoint.connectedAnchor = Vector3.zero;
            _length = Vector3.Distance(Hook.transform.position,RopeStart.position);
            SpringJoint.maxDistance = _length;
            SpringJoint.damper = Damper;
            SpringJoint.spring = SpringValue;
            RopeState = RopeState.Active;
        }
    }
    public void DestroySpring() 
    {
        if (SpringJoint) 
        {
            Destroy(SpringJoint);
            RopeState = RopeState.Disabled;
            Hook.gameObject.SetActive(false);
        }
    }

}
