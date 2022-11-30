using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Game Events", menuName = "Game Events")]
public class GameEvents : ScriptableObject
{
    public CheckpointPassedEvent CheckpointPassedEvent = new();
    public LastCheckpointEvent LastCheckpointEvent = new();
    public RaceTimerEvent RaceTimerEvent = new();
    public InteriorCameraEvent InteriorCameraEvent = new();
}

public class CheckpointPassedEvent : UnityEvent<Vector3, Quaternion> { }
public class LastCheckpointEvent : UnityEvent { }
public class RaceTimerEvent : UnityEvent { }
public class InteriorCameraEvent : UnityEvent<bool> { }