using UnityEngine;

public enum DriveType
{
    RearWheelDrive,
    FrontWheelDrive,
    AllWheelDrive
}

public class PlayerCarController : MonoBehaviour
{
	[Tooltip("Maximum steering angle of the wheels")]
	public float maxAngle = 30f;
	[Tooltip("Maximum torque applied to the driving wheels")]
	public float maxTorque = 300f;
	[Tooltip("Maximum brake torque applied to the driving wheels")]
	public float brakeTorque = 30000f;
	[Tooltip("If you need the visual wheels to be attached automatically, drag the wheel shape here.")]
	public GameObject wheelShape;
	[Tooltip("The scale of the wheel being instantiated")]
	public Vector3 wheelShapeScaleFactor;
	[Tooltip("The vehicle's speed when the physics engine can use different amount of sub-steps (in m/s).")]
	public float criticalSpeed = 5f;
	[Tooltip("Simulation sub-steps when the speed is above critical.")]
	public int stepsBelow = 5;
	[Tooltip("Simulation sub-steps when the speed is below critical.")]
	public int stepsAbove = 1;
	[Tooltip("The vehicle's drive type: rear-wheels drive, front-wheels drive or all-wheels drive.")]
	public DriveType driveType;

	[HideInInspector] public float angle, torque, handBrake;
	[HideInInspector] public float carSpeed;

	[Range(1, 10)]
	public float steerMaxFactor;
	public float steerMinAngle;

	private Rigidbody rb;
	private float steerMax;
	private float maxAngleOriginal;
	private WheelCollider[] m_Wheels;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
		m_Wheels = GetComponentsInChildren<WheelCollider>();
		maxAngleOriginal = maxAngle;

		for (int i = 0; i < m_Wheels.Length; ++i)
		{
			var wheel = m_Wheels[i];

			if (wheelShape != null)
			{
				var ws = Instantiate(wheelShape);
				ws.transform.parent = wheel.transform;
				ws.transform.localScale = wheelShapeScaleFactor;
			}
		}
	}

	public void Update()
	{
		m_Wheels[0].ConfigureVehicleSubsteps(criticalSpeed, stepsBelow, stepsAbove);

		angle = maxAngle * Input.GetAxis("Horizontal");
		torque = maxTorque * Input.GetAxis("Vertical");
		handBrake = Input.GetKey(KeyCode.X) ? brakeTorque : 0;

		for (int i = 0; i < m_Wheels.Length; i++)
		{
			if (m_Wheels[i].transform.localPosition.z > 0)
				m_Wheels[i].steerAngle = angle;

			if (m_Wheels[i].transform.localPosition.z < 0)
			{
				m_Wheels[i].brakeTorque = handBrake;
			}

			if (m_Wheels[i].transform.localPosition.z < 0 && driveType != DriveType.FrontWheelDrive)
			{
				m_Wheels[i].motorTorque = torque;
			}

			if (m_Wheels[i].transform.localPosition.z >= 0 && driveType != DriveType.RearWheelDrive)
			{
				m_Wheels[i].motorTorque = torque;
			}

			if (wheelShape == null)
			{
				return;
			}
			Quaternion q;
			Vector3 p;
			m_Wheels[i].GetWorldPose(out p, out q);

			Transform shapeTransform = m_Wheels[i].transform.GetChild(0);
			shapeTransform.position = p;
			shapeTransform.rotation = q;

			if (i == 0 || i == 2)
			{
				shapeTransform.Rotate(0, 180, 0);
			}
		}

		MaxAngleBySpeed();
	}

	private void MaxAngleBySpeed()
	{
		carSpeed = rb.velocity.magnitude;
		steerMax = maxAngleOriginal - (carSpeed / steerMaxFactor);
		if (steerMax > steerMinAngle)
		{
			maxAngle = steerMax;
		}
		else
		{
			maxAngle = steerMinAngle;
		}
	}
}
