using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuScript : MonoBehaviour
{
    public GameObject pauseUIGameObject;
    public void SetPause()
    {
        Time.timeScale = 0;
        pauseUIGameObject.SetActive(true);
    }
    public void Unpause()
    {
        Time.timeScale = 1;
        pauseUIGameObject.SetActive(false);
    }
}
