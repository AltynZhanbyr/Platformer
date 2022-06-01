using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowTimeScript : MonoBehaviour
{
    public float TimeScale;
    public float _startFixedDeltaTime=0.016666f;

    void Start()
    {
        Time.fixedDeltaTime = _startFixedDeltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            Time.timeScale = TimeScale;
        }
        else 
        {
            Time.timeScale = 1f;
        }
        Time.fixedDeltaTime = _startFixedDeltaTime * Time.timeScale;
    }
    private void OnDestroy()
    {
        Time.fixedDeltaTime = _startFixedDeltaTime;
    }
}
