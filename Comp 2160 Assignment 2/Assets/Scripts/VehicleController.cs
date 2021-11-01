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

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
}
