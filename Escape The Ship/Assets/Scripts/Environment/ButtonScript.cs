using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public bool isPressed = false;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }


    public void Press()
    {
        if (!isPressed)
        {
            animator.Play("ButtonPress");
            isPressed = true;
        }


        //if (isOpen && animator.GetCurrentAnimatorStateInfo(0).IsName("OpenIdle"))
        //{
        //    animator.Play("DoorClosing");
        //    isOpen = false;
        //}
        //else if (!isOpen && animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        //{
        //    animator.Play("DoorOpening");
        //    isOpen = true;
        //}

    }
}
