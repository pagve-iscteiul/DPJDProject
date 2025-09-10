using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerTrigger : MonoBehaviour
{
    public GameObject enemy = null;
    public GameObject guardRoute = null;
    public float spawnDelay = 0f;

    private bool triggered = false;
    private IEnumerator activeCoroutine;

    void OnTriggerExit(Collider other)
    {
        if (!triggered)
        {
            if (other.CompareTag("Player"))
            {
                activeCoroutine = SpawnWithDelay();
                StartCoroutine(activeCoroutine);

                triggered = true;
            }
        }
    }

    public void StopCycle()
    {
        StopCoroutine(activeCoroutine);
        activeCoroutine = null;
        triggered = false;
    }

    IEnumerator SpawnWithDelay()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnDelay);
            GameObject g = Instantiate(enemy, guardRoute.transform.position, guardRoute.transform.rotation);
            g.GetComponent<Guard>().route = guardRoute;

            if (spawnDelay == 0)
            {
                StopCycle();
            }
        }
    }
}

