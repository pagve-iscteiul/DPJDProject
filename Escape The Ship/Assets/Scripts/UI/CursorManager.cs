using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [SerializeField] private PauseMenu pauseMenu = null;
    [SerializeField] private GameObject centerPoint = null;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (pauseMenu.gameObject.activeSelf) 
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            centerPoint.SetActive(false);
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            centerPoint.SetActive(true);
        }

    }
}
