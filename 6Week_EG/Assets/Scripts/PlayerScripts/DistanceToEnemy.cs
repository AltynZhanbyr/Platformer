using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class DistanceToEnemy : MonoBehaviour
{
    public List<GameObject> Enemies;

    public float VisibleDist;

    void Start()
    {
        Enemies.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
    }

    void Update()
    {
        if (Enemies == null)
            return;

        Checking();
        EnemyActivate();
    }
    private void Checking() 
    {
        for (int i = 0; i < Enemies.Count; i++)
        {
            if (Enemies[i] == null)
            {
                Enemies.RemoveAt(i);
            }
        }
    }
    private void EnemyActivate() 
    {
        for (int i = 0; i < Enemies.Count; i++)
        {
            if (VisibleDist > Vector3.Distance(transform.position, Enemies[i].transform.position))
            {
                Enemies[i].SetActive(true);
            }
            else
            {
                Enemies[i].SetActive(false);
            }
        }
    }
#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.gray;
        Handles.DrawWireDisc(transform.position, Vector3.forward, VisibleDist);
    }
#endif
}
