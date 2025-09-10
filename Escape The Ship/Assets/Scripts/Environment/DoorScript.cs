using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public List<GameObject> buttons;
    public bool isOpen = false;

    public AudioSource openDoor;
    public AudioSource closeDoor;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }


    public void Activate()
    {

            if (isOpen && animator.GetCurrentAnimatorStateInfo(0).IsName("OpenIdle"))
            {
                Close();
            }
            else if(!isOpen && animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            {
                Open();
            }
        
    }

    public void Open()
    {
        if (!isOpen)
        {
            if(openDoor != null)
            {
                openDoor.Play();
            }
            animator.Play("DoorOpening");
            isOpen = true;
        }
    }

    public void Close()
    {
        if (isOpen)
        {
            if (closeDoor != null)
            {
                closeDoor.Play();
            }
            animator.Play("DoorClosing");
            isOpen = false;
        }
    }


    public void CheckButtons()
    {
        Debug.Log("Check");

        bool allTrue = true;
        foreach(GameObject g in buttons)
        {
            if (!g.GetComponent<ButtonScript>().isPressed)
            {
                allTrue = false;
                break;
            }
        }

        if (allTrue)
            Open();
    }


    //public void CheckPassword(string password)
    //{
    //    Debug.Log("test");

    //    if (item.value.ToString() == password)
    //        door.GetComponent<DoorScript>().Activate();
    //}
}
