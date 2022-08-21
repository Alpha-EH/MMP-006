using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour
{
    public AudioMixer mixer;

    public void SetLevel(float sliderValue)
    {
        // We need to convert values to logarithimic scale
        // because of decibels.
        mixer.SetFloat("MusicVolume", Mathf.Log10(sliderValue) * 20);
    }
}
