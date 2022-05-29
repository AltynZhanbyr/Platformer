using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum Direction
{
    Left,
    Right
}

public class Walker : MonoBehaviour
{
    public Transform LeftPoint;
    public Transform RightPoint;

    public float FreezeTime;

    private bool _isFreeze;

    public float Speed;

    public Direction CurrentDirection;

    public UnityEvent ToLeftPosition;
    public UnityEvent ToRightPosition;

    public Transform RayCast;

    void Start()
    {
        LeftPoint.parent = null;
        RightPoint.parent = null;
    }

    void Update()
    {
        if (_isFreeze) 
        {
            return;
        }

        if (CurrentDirection == Direction.Left)
        {
            transform.position -= new Vector3(Speed * Time.deltaTime, 0, 0);
            if (transform.position.x < LeftPoint.position.x) 
            {
                CurrentDirection = Direction.Right;
                _isFreeze = true;
                Invoke("StopFreeze",FreezeTime);
                ToRightPosition.Invoke();
            }
        }
        else 
        {
            transform.position += new Vector3(Speed * Time.deltaTime, 0, 0);
            if (transform.position.x > RightPoint.position.x)
            {
                CurrentDirection = Direction.Left;
                _isFreeze = true;
                Invoke("StopFreeze", FreezeTime);
                ToLeftPosition.Invoke();
            }
        }
        RaycastHit hit;
        Debug.DrawRay(RayCast.position, -RayCast.transform.up);
        if (Physics.Raycast(RayCast.position, -RayCast.transform.up, out hit)) 
        {
            transform.position = hit.point;
        }
    }
    private void StopFreeze() 
    {
        _isFreeze = false;
    }
}
