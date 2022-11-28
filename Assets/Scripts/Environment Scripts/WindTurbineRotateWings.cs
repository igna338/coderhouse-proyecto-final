using UnityEngine;

public class WindTurbineRotateWings : MonoBehaviour
{
    public float rotateSpeed;

    private void Awake()
    {
        float random = Random.Range(0, 7f);
        InvokeRepeating("RotateWings", random, Time.deltaTime);
    }

    private void RotateWings()
    {
        transform.Rotate(rotateSpeed, 0, 0);
    }
}
