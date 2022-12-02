using UnityEngine;

public class SkyAndSunRotate : MonoBehaviour
{
    public float SunRotateSpeed = 0.01f;
    public GameObject Sun;

    private void Awake()
    {
        InvokeRepeating("UpdateSunRotation", 1, Time.deltaTime);
    }

    private void UpdateSunRotation()
    {
        Sun.transform.Rotate(0.0f, SunRotateSpeed, 0.0f, Space.World);
    }
}
