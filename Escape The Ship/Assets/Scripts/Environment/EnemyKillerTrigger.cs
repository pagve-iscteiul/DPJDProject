using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKillerTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
    }
}
