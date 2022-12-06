using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCarRotate : MonoBehaviour
{
    public float rotationAmount;
    public float rotationRepeatRate;

    private void Start()
    {
        InvokeRepeating("UpdateRotation", 0.01f, rotationRepeatRate);
    }

    private void UpdateRotation()
    {
        transform.Rotate(0, rotationAmount, 0);
    }
}
