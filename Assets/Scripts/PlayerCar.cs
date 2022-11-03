using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCar : MonoBehaviour
{
    [Header("speeds y steering: a mas valor, mas es el efecto")]
    public float speed;
    public float steering;
    public float speedInertia;
    public float steeringSpeed;
    [Header("brakes: a mas valor, menos es el efecto")]
    public float brakes;

    private Rigidbody rb;
    private float steeringSpeedInverse;
    private float desiredRot;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        steeringSpeedInverse = (steeringSpeed * -1);
        desiredRot = transform.eulerAngles.y;
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            rb.AddForce(transform.forward * speed, ForceMode.Impulse);
        }

        if (Input.GetKey(KeyCode.S))
        {
            rb.velocity -= rb.velocity / brakes;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.down * steering * Time.deltaTime);

            if (rb.velocity.z > 1 || rb.velocity.z < -1)
            {
                rb.AddForce(transform.right * steeringSpeedInverse, ForceMode.Impulse);
            }
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * steering * Time.deltaTime);

            if (rb.velocity.z > 1 || rb.velocity.z < -1)
            {
                rb.AddForce(transform.right * steeringSpeed, ForceMode.Impulse);
            }
        }

        if (rb.velocity.z > 1 || rb.velocity.z < -1)
        {
            rb.AddForce(transform.forward * speedInertia, ForceMode.Impulse);
        }
    }
}
