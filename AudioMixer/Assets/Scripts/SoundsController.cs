using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundsController : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _mixer;
    [SerializeField] private Slider _totalVolumeSlider;
    [SerializeField] private Slider _buttonsVolumeSlider;
    [SerializeField] private Slider _backgroundVolumeSlider;

    private string _masterVolume = "MasterVolume";
    private string _backgroundVolume = "BackgroundVolume";
    private string _buttonsVolume = "ButtonsVolume";

    private void Start()
    {
        _totalVolumeSlider.value = PlayerPrefs.GetFloat(_masterVolume, 1);
        _buttonsVolumeSlider.value = PlayerPrefs.GetFloat(_buttonsVolume, 1);
        _backgroundVolumeSlider.value = PlayerPrefs.GetFloat(_backgroundVolume, 1);
    }

    public void ToggleMusic()
    {
        _mixer.audioMixer.GetFloat(_masterVolume, out float value);
        float currentVolume = value;

        if (currentVolume == -80)
            _mixer.audioMixer.SetFloat(_masterVolume, 0);
        else
            _mixer.audioMixer.SetFloat(_masterVolume, -80);
        
    }

    public void ChangeVolume(float volume)
    {
        _mixer.audioMixer.SetFloat(_masterVolume, Mathf.Lerp(-80, 0, volume));
        PlayerPrefs.SetFloat(_masterVolume, volume);
    }

    public void ChangeButtonsVolume(float volume)
    {
        _mixer.audioMixer.SetFloat(_buttonsVolume, Mathf.Lerp(-80, 0, volume));
        PlayerPrefs.SetFloat(_buttonsVolume, volume);
    }
    
    public void ChangeBackgrondVolume(float volume)
    {
        _mixer.audioMixer.SetFloat(_backgroundVolume, Mathf.Lerp(-80, 0, volume));
        PlayerPrefs.SetFloat(_backgroundVolume, volume);
    }
}