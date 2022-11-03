using UnityEngine;
using UnityEngine.SceneManagement;

public class RaceFinishManager : MonoBehaviour
{
    public GameEvents gameEvents;
    public Canvas RaceFinishWin;
    public Canvas RaceFinishLose;

    private void Awake()
    {
        gameEvents.LastCheckpointEvent.AddListener(OnLastCheckpoint);
        gameEvents.RaceTimerEvent.AddListener(OnRaceTimer);
    }

    private void OnLastCheckpoint()
    {
        RaceFinishWin.enabled = true;
        Time.timeScale = 0;
    }

    private void OnRaceTimer()
    {
        RaceFinishLose.enabled = true;
        Time.timeScale = 0;
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
