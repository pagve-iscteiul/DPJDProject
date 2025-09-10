using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewCone : MonoBehaviour
{
    
    public bool canSeePlayer()
    {
        foreach(Transform child in transform)
        {
            if (child.gameObject.GetComponent<ViewTrigger>().canSeePlayer)
            {
                return true;
            }
        }
        return false;
    }

    public GameObject getTarget()
    {
        foreach (Transform child in transform)
        {
            ViewTrigger trigger = child.gameObject.GetComponent<ViewTrigger>();
            if (trigger.canSeePlayer)
                return trigger.target.gameObject;
        }
        return null;
    }
}
