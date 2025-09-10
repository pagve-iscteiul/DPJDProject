using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopCoroutine : MonoBehaviour
{
    public EnemySpawnerTrigger routine;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            routine.StopCycle();
        }


    }
}
