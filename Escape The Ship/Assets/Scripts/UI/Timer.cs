using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timetext;
    public float timestart;
    //public AudioSource timersound; 

    // Start is called before the first frame update
    void Start()
    {
        timestart = Time.time;

        //timersound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float time = Time.time - timestart;

        float minutes = Mathf.Floor(time / 60);
        float seconds = Mathf.Floor(time % 60);

        timetext.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        //timersound.enabled = true;
    }
}
