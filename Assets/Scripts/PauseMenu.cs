using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour
{
    private bool isPaused;
    public GameObject pauseMenu;
    public AudioMixer audioMixerMaster;

    private void Awake()
    {
        audioMixerMaster.SetFloat("Volume", 0f);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            if (isPaused)
            {
                pauseMenu.SetActive(true);
                Time.timeScale = 0;
                audioMixerMaster.SetFloat("Volume", -80f);
            }
            else
            {
                Unpause();
            }
        }
    }

    public void Continue()
    {
        Unpause();
    }

    private void Unpause()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        audioMixerMaster.SetFloat("Volume", 0f);
    }
}
