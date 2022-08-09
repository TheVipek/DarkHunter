using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider slider;

    public string prefName;
    
    float sliderValueM = 0.8f;



    private void Start()
    {
        slider.value = PlayerPrefs.GetFloat(prefName, sliderValueM);
        slider.value = PlayerPrefs.GetFloat(prefName, sliderValueM);
    }




    public void SetLevelMusic(float sliderValue)
    {

        mixer.SetFloat("Volume", Mathf.Log10(sliderValue) * 20);
        sliderValueM = sliderValue;
        PlayerPrefs.SetFloat("levelSaveMusic", sliderValueM);

    }


    
    public void SetLevelSfx(float sliderValue)
    {

        mixer.SetFloat("Volume", Mathf.Log10(sliderValue) * 20);
        sliderValueM = sliderValue;
        PlayerPrefs.SetFloat("levelSaveSFX", sliderValueM);

    }
}
