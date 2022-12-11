using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class RaceFinishManager : MonoBehaviour
{
    public GameEvents gameEvents;
    public Canvas RaceFinishWin;
    public Canvas RaceFinishLose;
    public AudioMixer audioMixerMaster;

    private void Awake()
    {
        gameEvents.LastCheckpointEvent.AddListener(OnLastCheckpoint);
        gameEvents.RaceTimerEvent.AddListener(OnRaceTimer);
    }

    private void OnLastCheckpoint()
    {
        RaceFinishWin.enabled = true;
        Time.timeScale = 0;
        audioMixerMaster.SetFloat("Volume", -80f);
    }

    private void OnRaceTimer()
    {
        RaceFinishLose.enabled = true;
        Time.timeScale = 0;
        audioMixerMaster.SetFloat("Volume", -80f);
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        audioMixerMaster.SetFloat("Volume", 0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
