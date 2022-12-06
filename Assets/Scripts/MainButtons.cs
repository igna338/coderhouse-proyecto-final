using UnityEngine;
using UnityEngine.SceneManagement;


public class MainButtons : MonoBehaviour
{
    public GameObject carTrackSelect;
    private GameManager gameManager;

    public void Play()
    {
        carTrackSelect.SetActive(true);
    }

    public void MainMenu()
    {
        gameManager = GameManager.inst;
        Destroy(gameManager.gameObject);
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
