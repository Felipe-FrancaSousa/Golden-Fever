using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class OptionsMenu : MonoBehaviour
{
    public Musicas Musica;
    public TMP_Dropdown resolutionDropdown;
    public Toggle caixaFullscreen;
    public Toggle caixaMute;
    Resolution[] resolutions;
    void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
  

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height + " " + resolutions[i].refreshRate + "Hz";
            if(resolutions[i].width >= 640 && resolutions[i].height >= 480)
            {
                options.Add(option);
            }
            

            if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height && resolutions[i].refreshRate == Screen.currentResolution.refreshRate)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        if (Screen.fullScreen)
        {
            caixaFullscreen.isOn = true;
        }
        else
        {
            caixaFullscreen.isOn = false;
        }
    }
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen, resolution.refreshRate);
        Application.targetFrameRate = resolution.refreshRate;
    }

    public void SetVolume(Slider slider)
    {
        Musicas.MudarVolume(slider.value);
    }

    public void SetFullscreen (bool isFullscreen)
    {
  
        Screen.fullScreen = isFullscreen;
    }
    public void SetMute ()
    {
        if (caixaMute.isOn)
        {
            for (int i = 0; i < Musica.MusicasAmbiente.Length; i++)
            {
                Musica.MusicasAmbiente[i].mute = true;
            }
        }
        else
        {
            for (int i = 0; i < Musica.MusicasAmbiente.Length; i++)
            {
                Musica.MusicasAmbiente[i].mute = false;
            }
        }
    }

   
}
