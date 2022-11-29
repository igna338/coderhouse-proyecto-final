using UnityEngine;

public class CameraInteriorFollow : MonoBehaviour
{
    public float steeringFactor;
    public float speedFactor;
    public Transform target;

    private void Update()
    {
        var steer = Input.GetAxis("Horizontal") * steeringFactor;
        var speed = Input.GetAxis("Vertical") * speedFactor * -1;

        var newPos = new Vector3(steer, 0, speed);
        transform.localPosition = target.localPosition + newPos;

        var newRot = new Quaternion(0, 0, steer, 1);
        transform.localRotation = target.localRotation * newRot;
    }
}
