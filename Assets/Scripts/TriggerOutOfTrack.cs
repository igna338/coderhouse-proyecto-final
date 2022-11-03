using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerOutOfTrack : MonoBehaviour
{
    public GameEvents gameEvents;
    public GameObject playerCar;
    private Rigidbody playerCarRb;
    private Vector3 respawnPos;
    private Quaternion respawnRot;

    private void Awake()
    {
        respawnPos = playerCar.transform.position;
        respawnRot = playerCar.transform.rotation;
        playerCarRb = playerCar.GetComponent<Rigidbody>();
        gameEvents.CheckpointPassedEvent.AddListener(OnCheckPointPassed);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            ResetCar();
        }
    }

    private void OnCheckPointPassed(Vector3 newRespawnPos, Quaternion newRespawnRot)
    {
        respawnPos = newRespawnPos;
        respawnRot = newRespawnRot;
    }

    private void OnTriggerEnter(Collider other)
    {
        ResetCar();
    }

    private void ResetCar()
    {
        playerCarRb.velocity = playerCarRb.velocity * 0;
        playerCar.transform.position = respawnPos;
        playerCar.transform.rotation = respawnRot;
    }
}
