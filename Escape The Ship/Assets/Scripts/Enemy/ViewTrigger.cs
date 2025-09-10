using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewTrigger : MonoBehaviour
{
    public LayerMask targetMask;
    public LayerMask obstructionMask;

    public float minimumViewDistance = 5f;
    [HideInInspector]
    public bool canSeePlayer = false;
    public Transform target;


    void OnTriggerEnter(Collider other)
    {
        if (1 << other.gameObject.layer == targetMask.value)
        {
            target = other.gameObject.transform;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (target != null)
        {
            Transform currentPosition = transform.parent;
            Vector3 directionToTarget = (target.position - currentPosition.position).normalized;
            float distanceToTarget = Vector3.Distance(currentPosition.position, target.position);

            if (!Physics.Raycast(currentPosition.position, directionToTarget, distanceToTarget, obstructionMask))
            {
                if (distanceToTarget < minimumViewDistance)
                    canSeePlayer = true;
            }
            else
                canSeePlayer = false;
        }
    }

    void OnTriggerExit()
    {
        target = null;
        canSeePlayer = false;
    }
}
