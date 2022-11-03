using System.Collections.Generic;
using UnityEngine;

public class CheckpointsManager : MonoBehaviour
{
    public GameEvents gameEvents;
    public List<GameObject> checkpoints;
    private int currentCheckpoint;
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
            if (currentCheckpoint == checkpoints.Count - 1)
            {
                checkpoints[0].SetActive(true);
                isRaceFinish = true;
            }
            else
            {
                checkpoints[currentCheckpoint].SetActive(true);
            }
        }
    }
}