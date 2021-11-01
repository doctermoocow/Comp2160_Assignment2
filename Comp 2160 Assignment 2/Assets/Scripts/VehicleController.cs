using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleController : MonoBehaviour
{
    //designer configuration
    public float horsepower = 150;
    public float maxSteeringAngle = 30;

    public Wheel[] poweredWheels;
    public Wheel[] steeringWheels;


    float accelInput;
    float turningInput;

    //Center of mass Tuning
    public bool debug;
    Rigidbody rigidBody;
    public Vector3 cOM;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidBody.centerOfMass = cOM;
        accelInput = Input.GetAxis("Vertical");
        turningInput = Input.GetAxis("Horizontal");


        
        foreach(Wheel wheel in poweredWheels)
        {
            wheel.Acceleration(accelInput * horsepower);
            
        }

        foreach (Wheel wheel in steeringWheels)
        {
            wheel.Steering(turningInput, maxSteeringAngle);
        }


    }

    private void OnDrawGizmos()
    {
        if (debug)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(transform.position + transform.rotation * rigidBody.centerOfMass, 0.01f);
        }
    }
}
