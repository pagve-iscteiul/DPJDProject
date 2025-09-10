using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsScript : MonoBehaviour {

    public Slider audioSlider;
    public Dropdown resolutiondropdown;
    Resolution[] resolutionslist;
    public Dropdown qualitydropdown;
    public bool setVolume = false;

    void Awake()
    {
        if (setVolume)
        {
            AudioListener.volume = 0.5f;
        }

        audioSlider.value = AudioListener.volume;

        resolutionslist = Screen.resolutions;
        List<string> resolutionresultlist = new List<string>();
        int ResolutionLevel = 0;

        for (int i = 0; i < resolutionslist.Length; i++)
        {
            string resolutionresult = resolutionslist[i].width + " x " + resolutionslist[i].height;
            resolutionresultlist.Add(resolutionresult);
            if(resolutionslist[i].width == Screen.currentResolution.width && resolutionslist[i].height == Screen.currentResolution.height)
            {
                ResolutionLevel = i;
            }
        }
        resolutiondropdown.AddOptions(resolutionresultlist);
        resolutiondropdown.value = ResolutionLevel;
        resolutiondropdown.RefreshShownValue();
    }

    public void changeVolume()
    {
        AudioListener.volume = audioSlider.value;
    }

    public void ResolutionUpdate(int resolutionlevel)
    {
        Resolution resolution = resolutionslist[resolutionlevel];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void Quality(int qualitylevel)
    {
        QualitySettings.SetQualityLevel(qualitylevel, false);
    }

    public void Fullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
