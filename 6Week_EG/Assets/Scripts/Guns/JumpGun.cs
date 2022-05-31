using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpGun : MonoBehaviour
{
    public Rigidbody Rigidbody;
    public float Speed;
    public Transform Spawn;
    public Gun Weapon;

    public float MaxTime;
    private float _currentTime;
    private bool _isTime;

    public JumpGunImageTimer JumpAttackTime;

    void Update()
    {

        if (_isTime)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift)) 
            {
                JumpShot();
            }
        }
        else 
        {
            _currentTime += Time.deltaTime;
            JumpAttackTime.SetChargeValue(_currentTime,MaxTime);
            if (_currentTime >= MaxTime) 
            {
                _isTime = true;
                JumpAttackTime.StopCharge();
            }
        }
    }
    private void JumpShot() 
    {
        Rigidbody.AddForce(-Spawn.forward * Speed, ForceMode.VelocityChange);
        Weapon.Shot();
        _isTime = false;
        _currentTime = 0f;
        JumpAttackTime.StartCharge();
    }
}
