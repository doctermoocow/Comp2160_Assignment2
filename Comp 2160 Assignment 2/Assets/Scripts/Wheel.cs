using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Wheel : MonoBehaviour
{
    
    public Transform wheelMesh;
    public Vector3 meshOffset; //allows individual control of the location of the wheel mesh compare to the wheel collider

    private WheelCollider wheelCol;

    // Start is called before the first frame update
    void Start()
    {
        wheelCol = GetComponentInChildren<WheelCollider>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // makes the mesh move to the same position as the wheel collider

        wheelCol.GetWorldPose(out Vector3 position, out Quaternion rotation);
       // position = new Vector3(position.x -0.62f, position.y, position.z);
        wheelMesh.transform.localPosition = transform.InverseTransformPoint(position) + meshOffset;
        wheelMesh.transform.rotation = rotation;
    }

    public void Acceleration(float power)
    {
        wheelCol.motorTorque = power;
        wheelCol.brakeTorque = 0;
    }

    public void Braking(float brakingPower)
    {
        wheelCol.brakeTorque = brakingPower;
    }

    public void  Steering(float steering, float maxSteeringAngle)
    {
        wheelCol.steerAngle = steering * maxSteeringAngle;
    }
}
