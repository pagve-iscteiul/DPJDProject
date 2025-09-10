using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoorController : MonoBehaviour
{
    [SerializeField] private GameObject myDoor = null;
    [SerializeField] private bool openTrigger = false;
    [SerializeField] private bool closeTrigger = false;
    [SerializeField] private bool enemyTrigger = false;

    //private bool triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        string tag = "Player";

        if (enemyTrigger)
            tag = "Enemy";

        if (other.CompareTag(tag))
        {
            //if (!triggered)
            //{
                if (openTrigger)
                {
                    //myDoor.Play("DoorOpening", 0, 0.0f);
                    myDoor.GetComponent<DoorScript>().Open();
                    //triggered = true;
                }
                else if (closeTrigger)
                {
                    //myDoor.Play("DoorClosing", 0, 0.0f);
                    myDoor.GetComponent<DoorScript>().Close();
                    //triggered = true;
                }
            //}
        }
    }

}
