using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeVolumeLevel : MonoBehaviour
{

    public Slider thisSlider;
    public float musicVolume;
    public float ambVolume;
    public float sfxVolume;


    public void SetVolume(string whatValue)
    {
        float sliderValue = thisSlider.value;

        if (whatValue == "Music")
        {
            Debug.Log("Changed Music level to:" +  thisSlider.value);
            musicVolume = thisSlider.value;
            AkSoundEngine.SetRTPCValue("MusicVolume", musicVolume); // tell wwise to set RTPC value to match the value of musicVolume
        }

        if (whatValue == "Ambience")
        {
            Debug.Log("Changed Music level to:" + thisSlider.value);
            ambVolume = thisSlider.value;
            AkSoundEngine.SetRTPCValue("AmbVolume", ambVolume);
        }

        if (whatValue == "SFX")
        {
            Debug.Log("Changed Music level to:" + thisSlider.value);
            sfxVolume = thisSlider.value;
            AkSoundEngine.SetRTPCValue("SFXVolume", sfxVolume);
        }


    }


}
