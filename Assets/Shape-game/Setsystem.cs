using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Setsystem : MonoBehaviour
{
    [SerializeField] private Slider Mainslider, musicslider, effectslider;
    [SerializeField] private AudioMixer audiomix;

    void Start()
    {
        VolumeSet();
    }

   public void MainVolumChange()
    {
        audiomix.SetFloat("Main", Mainslider.value);
    }
    public void MusicVolumChange()
    {
        audiomix.SetFloat("Music", musicslider.value);
    }
    public void EffectVolumChange()
    {
        audiomix.SetFloat("Effect", effectslider.value);
    }
    public void SaveSet()
    {
        PlayerPrefs.SetFloat("Main", Mainslider.value);
        PlayerPrefs.SetFloat("Music", musicslider.value);
        PlayerPrefs.SetFloat("Effect", effectslider.value);
    }
    public void DefaultSet()
    {
        VolumeSet();
    }

    private void VolumeSet()
    {
        Mainslider.value = PlayerPrefs.GetFloat("Main", 0);
        musicslider.value = PlayerPrefs.GetFloat("Music", 0);
        effectslider.value = PlayerPrefs.GetFloat("Effect", 0);
    }

}
