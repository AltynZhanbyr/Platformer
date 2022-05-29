using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAnimationTimer : MonoBehaviour
{
    public float AttackTime;
    public Animator Animator;
    private float _timer;
    public LayerMask LayerMask;
    public string TriggerName;

    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= AttackTime)
        {
            _timer = 0;
            Animator.SetTrigger(TriggerName);
        }
    }
}
