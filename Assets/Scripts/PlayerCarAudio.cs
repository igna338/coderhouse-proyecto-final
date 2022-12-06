using UnityEngine;

public class PlayerCarAudio : MonoBehaviour
{
    public PlayerCarController carController;
    private AudioSource audioSource;
    public float minPitch = 0.05f;
    public float maxPitch;
    public float speedFactor;
    private float pitchFromCar;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.pitch = minPitch;
    }

    private void Update()
    {
        EnginePitch();
    }

    private void EnginePitch()
    {
        pitchFromCar = carController.carSpeed / speedFactor;
        if (pitchFromCar < minPitch)
            audioSource.pitch = minPitch;
        if (pitchFromCar > maxPitch)
            audioSource.pitch = maxPitch;
        else
            audioSource.pitch = pitchFromCar;
    }
}
