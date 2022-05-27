using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotate : MonoBehaviour
{
   private Transform _playerTransform;
    void Start()
    {
        _playerTransform=FindObjectOfType<PlayerHealth>().transform;
    }

    void Update()
    {
        Vector3 delta=_playerTransform.position-transform.position;
        transform.rotation=Quaternion.Lerp(transform.rotation,Quaternion.LookRotation(new Vector3(delta.x,0f,delta.z)),Time.deltaTime*15);
    }
}
