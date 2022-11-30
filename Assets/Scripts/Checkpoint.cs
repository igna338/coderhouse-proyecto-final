using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public GameEvents gameEvents;
    public AudioSource checkpointSFX;

    private void OnTriggerEnter(Collider other)
    {
        gameEvents.CheckpointPassedEvent.Invoke(transform.position, transform.rotation);
        checkpointSFX.Play();
    }
}