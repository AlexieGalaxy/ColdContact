using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer masterMixer, musicMixer, voiceMixer;
    public TMPro.TMP_Dropdown resolutionDropdown;

    public TMPro.TMP_Text masterValue, musicValue, voiceValue;
    public Slider masterSlider, musicSlider, voiceSlider;

    private Resolution[] userResolutions;

    private void Start()
    {
        userResolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        for (int i = 0; i < userResolutions.Length; i++)
        {
            string option = userResolutions[i].width + " * " + userResolutions[i].height;
            options.Add(option);

            if (userResolutions[i].width == Screen.currentResolution.width &&
                    userResolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void Update()
    {
        masterValue.text = Mathf.Ceil(masterSlider.value * 100f) + "%";
        musicValue.text = Mathf.Ceil(musicSlider.value * 100f) + "%";
        voiceValue.text = Mathf.Ceil(voiceSlider.value * 100f) + "%";
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = userResolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetMasterVolume(float volume)
    {
        masterMixer.SetFloat("masterVolume", volume);
    }

    public void SetMusicVolume(float volume)
    {
        musicMixer.SetFloat("musicVolume", volume);
    }

    public void SetVoiceVolume(float volume)
    {
        voiceMixer.SetFloat("voiceVolume", volume);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
