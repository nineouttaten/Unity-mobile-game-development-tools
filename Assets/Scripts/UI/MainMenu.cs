using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject settingsGameObject;
    
    public void SettingsButton()
    {
        settingsGameObject.SetActive(!settingsGameObject.active);
    }
    
    public void ExitButton()
    {
        Application.Quit();
    }
}
