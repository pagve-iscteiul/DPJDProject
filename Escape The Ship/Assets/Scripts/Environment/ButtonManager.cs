using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private GameObject associatedDoor = null;
    //[SerializeField] private Animator associatedDoor = null;
    private bool doorIsOpen = true;


    void OnMouseDown()
    {
        associatedDoor.GetComponent<DoorScript>().Activate();


        //if (doorIsOpen)
        //{
        //    associatedDoor.Play("CloseDoor", 0, 0.0f);
        //    doorIsOpen = false;
        //}
        //else
        //{
        //    associatedDoor.Play("OpenDoor", 0, 0.0f);
        //    doorIsOpen = true;
        //}

    }

}
