using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckpointsManager : MonoBehaviour
{
    public GameEvents gameEvents;
    public List<GameObject> checkpoints;
    public int raceLaps;
    public int currentCheckpoint;
    public Text lapsText;
    private int lapsDone;
    private int lapsDoneUI;
    private bool isRaceFinish;
    private bool refreshLapsUI;

    private void Awake()
    {
        gameEvents.CheckpointPassedEvent.AddListener(OnCheckpointPassed);
        lapsDoneUI = 1;
        lapsText.text = "Laps\n" + lapsDoneUI + " / " + raceLaps;
    }

    private void OnCheckpointPassed(Vector3 chkPos, Quaternion chkRot)
    {
        if (refreshLapsUI)
        {
            lapsText.text = "Laps\n" + lapsDoneUI + " / " + raceLaps;
            refreshLapsUI = false;
        }
        if (isRaceFinish)
        {
            gameEvents.LastCheckpointEvent.Invoke();
        }
        else
        {
            checkpoints[currentCheckpoint].SetActive(false);
            currentCheckpoint++;
            if (currentCheckpoint == checkpoints.Count)
            {
                currentCheckpoint = 0;
                checkpoints[0].SetActive(true);
                lapsDone++;
                lapsDoneUI++;
                refreshLapsUI = true;
                if (lapsDone == raceLaps)
                {
                    isRaceFinish = true;
                }
            }
            else
            {
                checkpoints[currentCheckpoint].SetActive(true);
            }
        }
    }
}