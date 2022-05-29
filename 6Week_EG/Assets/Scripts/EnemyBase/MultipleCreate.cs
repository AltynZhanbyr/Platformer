using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleCreate : MonoBehaviour
{
    public Transform[] Spawns;
    public GameObject Prefab;

    [ContextMenu("Create")]
    public void Create() 
    {
        for (int i = 0; i < Spawns.Length; i++)
        {
            Instantiate(Prefab,Spawns[i].position, Spawns[i].rotation);
        }
    }
}
