using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
    public GameObject door;
    public GameObject player;

    void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.F))
        {
            transform.parent.gameObject.GetComponent<ButtonScript>().Press();
            door.GetComponent<DoorScript>().CheckButtons();
            //Debug.Log("Press");
        }
    }
}
