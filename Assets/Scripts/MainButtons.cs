using UnityEngine;
using UnityEngine.SceneManagement;


public class MainButtons : MonoBehaviour
{
    public GameObject carTrackSelect;

    public void Play()
    {
        carTrackSelect.SetActive(true);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
