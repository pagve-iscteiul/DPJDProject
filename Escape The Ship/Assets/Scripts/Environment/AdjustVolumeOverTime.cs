using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustVolumeOverTime : MonoBehaviour
{
    public AudioSource sound;

    public float targetVolume = 0f;
    public float duration = 5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartFade(sound, duration, targetVolume));
    }

    public static IEnumerator StartFade(AudioSource audioSource, float duration, float targetVolume)
    {
        float currentTime = 0;
        float start = audioSource.volume;
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }
        yield break;
    }
}
