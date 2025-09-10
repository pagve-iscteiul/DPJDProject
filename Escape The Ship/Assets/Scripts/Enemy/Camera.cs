using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Camera : MonoBehaviour
{
    public float degreesPerSecond = 30f;
    public float rotationFreedom = 90f;
    public float timeStopped = 0f;
    public float angleTolerance = 1f;

    private float degreesRotated = 0f;
    private Quaternion startRotation;
    private float timeKeeper = 0f;
    private bool isStoped = true;
    //private bool reachedRotation = false;
    
    //private AudioSource rotateCameraSound;
    public GameObject gameover;
    private ViewCone viewCone;
    private bool caught = false;

    Quaternion targetRotation;


    void Start()
    {
        viewCone = transform.Find("ViewCone").gameObject.GetComponent<ViewCone>();
        //rotateCameraSound = GetComponent<AudioSource>();

        startRotation = transform.rotation;
        Vector3 direction = new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, rotationFreedom);
        targetRotation = Quaternion.Euler(direction);
    }

    void Update()
    {
        if (caught)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }

        CheckCone();

        RotateCamera();
    }

    void CheckCone()
    {
        if (viewCone.canSeePlayer())
        {
            caught = true;
            Time.timeScale = 0;
            GameObject.Find("Main Camera").GetComponent<AudioListener>().enabled = false;
            //guardFootstep.Stop();
            //agent.isStopped = true;
            //playerController.canMove = false;
            //guardFootstep.enabled = false;

            Instantiate(gameover);
        }

        //if (this.viewCone.canSeePlayer())
        //{
        //    isStoped = true;
        //    player.canMove = false;
        //    GetPlayer(this);
        //    TryAgain();
        //    camera.GetComponent<AudioListener>().enabled = false;
        //}
    }

    void RotateCamera()
    {
        if (!isStoped)
        {
            //rotateCameraSound.enabled = true;
            transform.Rotate(0, 0, degreesPerSecond * Time.deltaTime);
            degreesRotated += degreesPerSecond * Time.deltaTime;

            if (Math.Abs(degreesRotated) >= rotationFreedom)
            {
                if (degreesPerSecond < 0)
                    transform.rotation = startRotation;
                else
                    transform.rotation = targetRotation;
                //rotateCameraSound.Play();
                degreesPerSecond *= -1;
                degreesRotated = 0;
                isStoped = true;
            }
        }
        else
        {
            timeKeeper += Time.deltaTime;
            //rotateCameraSound.enabled = false;
            if (timeKeeper >= timeStopped)
            {
                isStoped = false;
                timeKeeper = 0;
            }
        }
    }

    //public void Sabotage()
    //{
    //    rotateCameraSound.enabled = false;
    //    this.enabled = false;
    //}

    //public void GetPlayer(Camera camera)
    //{
    //    Instantiate(gameover);
    //    //camera.gameover.SetActive(true);
    //    //Debug.Log("Caught By Camera");
    //}

    //public void TryAgain()
    //{
    //    if(Input.GetKeyDown(KeyCode.R))
    //    {
    //        SceneManager.LoadScene("SimplifiedLevel");
    //    }
    //}
}
