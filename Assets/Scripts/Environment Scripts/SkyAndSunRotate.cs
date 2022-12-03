using UnityEngine;

public class SkyAndSunRotate : MonoBehaviour
{
    public float SunRotateRate = 0.1f;
    public float SunRotateSpeed = 0.1f;
    public GameObject Sun;

    private void Awake()
    {
        InvokeRepeating("UpdateSunRotation", 1, SunRotateRate);
    }

    private void UpdateSunRotation()
    {
        Sun.transform.Rotate(0.0f, SunRotateSpeed, 0.0f, Space.World);
    }
}
