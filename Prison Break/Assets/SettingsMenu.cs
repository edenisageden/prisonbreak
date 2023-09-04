using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    [SerializeField] private Slider audioSlider;
    [SerializeField] private Toggle postProcessingToggle, screenshakeToggle;

    private void Start()
    {
        float value;
        audioMixer.GetFloat("Volume", out value);
        audioSlider.value = value;

        InitializeToggles();
    }
    private void Awake()
    {
        MonobehaviourUtility.OnDataDeleted += InitializeToggles;
    }
    private void OnDestroy()
    {
        MonobehaviourUtility.OnDataDeleted -= InitializeToggles;
    }

    private void InitializeToggles()
    {
        if (PlayerPrefs.GetInt("Screenshake") == 0) screenshakeToggle.isOn = true;
        else screenshakeToggle.isOn = false;

        if (PlayerPrefs.GetInt("PostProcessing") == 0) postProcessingToggle.isOn = true;
        else postProcessingToggle.isOn = false;
    }

    public void SetPostProcessing(bool isOn)
    {
        if (isOn) PlayerPrefs.SetInt("PostProcessing", 0);
        else PlayerPrefs.SetInt("PostProcessing", 1);
    }
    public void SetScreenshake(bool isOn)
    {
        if (isOn) PlayerPrefs.SetInt("Screenshake", 0);
        else PlayerPrefs.SetInt("Screenshake", 1);
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }
}
