using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    
    public static bool isPaused = false;
    public GameObject PM;
    //public GameObject UI;
    //public PlayerController playercamera;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (isPaused)
            {
                Resume();
            } 
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        Debug.Log("Game Resumed");
        PM.SetActive(false);
        //UI.SetActive(true);
        Time.timeScale = 1f;
    }
    public void Pause()
    {
        Debug.Log("Game Paused");
        PM.SetActive(true);
        //UI.SetActive(false);
        Time.timeScale = 0f;
    }
    public void Restart()
    {
        Debug.Log("Game Restarted");
        SceneManager.LoadScene("Final");
        Time.timeScale = 1f;
    }

    public void Quit()
    {
        Debug.Log("Quitting Game");
        SceneManager.LoadScene("MainMenuScene");
    }
}
