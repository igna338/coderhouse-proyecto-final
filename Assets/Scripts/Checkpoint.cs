using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public GameEvents gameEvents;

    private void OnTriggerEnter(Collider other)
    {
        gameEvents.CheckpointPassedEvent.Invoke(transform.position, transform.rotation);
    }
}