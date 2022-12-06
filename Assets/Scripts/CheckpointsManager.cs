using System.Collections.Generic;
using UnityEngine;

public class CheckpointsManager : MonoBehaviour
{
    public GameEvents gameEvents;
    public List<GameObject> checkpoints;
    public int raceLaps;
    public int currentCheckpoint;
    private int lapsDone;
    private bool isRaceFinish;

    private void Awake()
    {
        gameEvents.CheckpointPassedEvent.AddListener(OnCheckpointPassed);
    }

    private void OnCheckpointPassed(Vector3 chkPos, Quaternion chkRot)
    {
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