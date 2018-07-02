using UnityEngine;
using System.Collections;

public class CarController : MonoBehaviour {
	public WheelCollider leftFrontWheel;
	public WheelCollider rightFrontWheel;
	public WheelCollider leftBackWheel;
	public WheelCollider rightBackWheel;
	
	public Transform leftFrontVisuals;
	public Transform rightFrontVisuals;
	public Transform leftBackVisuals;
	public Transform rightBackVisuals;
    [SerializeField]
	private float maxTorque = 750.0F;
    [SerializeField]
    private float maxBrakeTorque = 900.0F;
    [SerializeField]
    private float steerAngle = 30;
    [SerializeField]
    private float maxSpeed = 250;
    [SerializeField]
    private float downforce = 100f;
    [SerializeField]
    private float slipLimit = 0.1F;
    [SerializeField]
    public float currentMotorTorque = 0;

	private Rigidbody myRigidbody;
	private float velocityMagnitude = 0;


	void Awake ()
	{	
		myRigidbody = GetComponent<Rigidbody>(); 
	}
	
	void FixedUpdate () {
				

		float thrustTorque = 0;
		thrustTorque = currentMotorTorque * Input.GetAxis("Vertical");

		velocityMagnitude = myRigidbody.velocity.magnitude; 
		float speed = velocityMagnitude;
		speed *= 3.6f;
		if (speed >= maxSpeed)
			thrustTorque = 0;


        leftBackWheel.motorTorque =  thrustTorque / 2;
        rightBackWheel.motorTorque = thrustTorque / 2;	

		if (Input.GetKey(KeyCode.Space))
		{
            leftBackWheel.brakeTorque = maxBrakeTorque;
            rightBackWheel.brakeTorque = maxBrakeTorque;
		}
		else
		{
            leftBackWheel.brakeTorque = 0;
            rightBackWheel.brakeTorque = 0;
		}
		
		leftFrontWheel.steerAngle = steerAngle * Input.GetAxis("Horizontal");
		rightFrontWheel.steerAngle = steerAngle *  Input.GetAxis("Horizontal");	

		AddDownForce(); 

        TractionControl();
    }

    private void TractionControl()
    {

        WheelHit wheelHit;

        leftBackWheel.GetGroundHit(out wheelHit);
        AdjustTorque(wheelHit.forwardSlip);

        rightBackWheel.GetGroundHit(out wheelHit);
        AdjustTorque(wheelHit.forwardSlip);
    }

    private void AdjustTorque(float forwardSlip)
	{
		if (forwardSlip >= slipLimit && currentMotorTorque >= 0)
		{
			currentMotorTorque -= 1;
		}
		else
		{
			currentMotorTorque += 10;
			if (currentMotorTorque >  maxTorque)
			{
				currentMotorTorque = maxTorque;
			}
		}
	}

	private void AddDownForce()
	{
		myRigidbody.AddForce(-transform.up * downforce * velocityMagnitude);
	}

	void Update()
	{
		RefreshVisuals(leftFrontWheel,leftFrontVisuals);		
		RefreshVisuals(rightFrontWheel,rightFrontVisuals);
		RefreshVisuals(leftBackWheel,leftBackVisuals);
		RefreshVisuals(rightBackWheel,rightBackVisuals);
	}
	void RefreshVisuals(WheelCollider wc, Transform visualWheel)
	{
		Quaternion quat;
		Vector3 position;
		wc.GetWorldPose(out position, out quat);
		visualWheel.transform.position = position;
		visualWheel.transform.rotation = quat;
	}
}
