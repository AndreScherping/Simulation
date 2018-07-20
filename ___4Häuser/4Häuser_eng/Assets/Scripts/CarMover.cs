using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMover : MonoBehaviour
{
    public Transform path;
    private List<Transform> points;
    private int currentPoint = 0;

    public WheelCollider wheelFl;
    public WheelCollider wheelFr;
    public WheelCollider wheelBl;
    public WheelCollider wheelBr;
    public float maxSteerAngle = 45f;
    public float maxMotorTorque = 200f;
    public float currentSpeed;
    public float maxSpeed;

	void Start ()
    {
        Transform[] pathTransforms = path.GetComponentsInChildren<Transform>();
        points = new List<Transform>();

        for (int i = 0; i < pathTransforms.Length; i++)
        {
            if (pathTransforms[i] != path.transform)
            {
                points.Add(pathTransforms[i]);
            }
        }
    }
	void FixedUpdate ()
    {
        ApplySteering();
        Driving();
        CheckPointsDistance();
        Debug.Log("Steer : " + wheelFl.steerAngle);
    }
    private void ApplySteering()
    {
        Vector3 realtivVector = transform.InverseTransformPoint(points[currentPoint].position);
        Debug.Log("relativVector Point : "+ realtivVector);
        realtivVector = realtivVector / realtivVector.magnitude;
        float newSteer = (realtivVector.x /= realtivVector.magnitude) * maxSteerAngle;
        wheelFl.steerAngle = newSteer;
        wheelFr.steerAngle = newSteer;
    }
    private void Driving()
    {
        currentSpeed = 2 * Mathf.PI * wheelFl.radius * wheelFl.rpm * 60 / 1000;

        if (currentSpeed < maxSpeed)
        {
            wheelFl.motorTorque = 100f;
            wheelFr.motorTorque = 100f;
        }

    }
    private void CheckPointsDistance()
    {
        if (Vector3.Distance(transform.position, points[currentPoint].position) < 0.5f)
        {
            if (currentPoint == points.Count - 1)
            {
                currentPoint = 0;
            }
            else
            {
                currentPoint++;
            }
        }
    }
}
