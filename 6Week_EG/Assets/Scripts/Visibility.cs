using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visibility : MonoBehaviour
{

    private void OnBecameVisible()
    {
        gameObject.SetActive(true);
       
    }
    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
       
    }
}
