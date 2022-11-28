using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInteriorFollow : MonoBehaviour
{
    public float steer;
    public float speed;

    void Update()
    {
        steer = Input.GetAxis("Horizontal") * 2;
        speed = Input.GetAxis("Vertical") * 2;
    }
}
