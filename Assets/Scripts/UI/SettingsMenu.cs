using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public AudioMixer musicMixer;

    public TMP_Dropdown resolutionDropdown;
    
    private Resolution[] resolutions;
    
    List<int> possibleResolutionIndexes = new List<int>();
    private void Start()
    {
        //SetFullscreen(true);
        
        resolutions = Screen.resolutions;
        
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        
        
        int currentResolutionIndex = 0;
        int maxRefreshRate = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            if (resolutions[i].refreshRate > maxRefreshRate)
            {
                maxRefreshRate = resolutions[i].refreshRate;
            }
        }

        Application.targetFrameRate = maxRefreshRate;
        
        for (int i = 0; i < resolutions.Length; i++)
        {
            if (resolutions[i].refreshRate == maxRefreshRate)
            {
                string option = resolutions[i].width + " X " + resolutions[i].height + 
                                " @ " + resolutions[i].refreshRate + "HZ";
                options.Add(option);

                possibleResolutionIndexes.Add(i);
                
                if (resolutions[i].width == Screen .currentResolution.width &&
                    resolutions[i].height == Screen .currentResolution.height)
                {
                    currentResolutionIndex = i;
                }
            }
        }
        
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetAudio(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
    
    public void SetMusic(float volume)
    {
        musicMixer.SetFloat("volume", volume);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[possibleResolutionIndexes[resolutionIndex]];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
