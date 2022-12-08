using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private bool isPaused;
    public GameObject pauseMenu;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            if (isPaused)
            {
                pauseMenu.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                pauseMenu.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }

    public void Continue()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
}
