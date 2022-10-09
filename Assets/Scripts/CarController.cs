using System.Collections;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.IO.Compression;

public class CarController : MonoBehaviour
{
    [SerializeField] private List<Axle> axles;
    [SerializeField] private float maxSteeringAngle = 20;
    [SerializeField] private float maxMotorTorque = 400;
    [SerializeField] private GameObject rpmCounter;

    private float steering;
    private float motorTorque;

    private bool brake = false;
    void Update()
    {
        //get the input
        

        if (Input.GetKey(KeyCode.Space))
            brake = true;
        else
            brake = false;
    }

    private void FixedUpdate()
    {
        //set the steering angle of the front wheels
        foreach (Axle axle in axles)
        {
            steering = Input.GetAxis("Horizontal") * maxSteeringAngle;
            motorTorque = Input.GetAxis("Vertical") * maxMotorTorque;

            if (axle.steering)
            {
                axle.left.steerAngle = steering;
                axle.right.steerAngle = steering;
            }

            if (brake)
            {
                //Debug.Log("Braking");
                //axle.left.brakeTorque = 100;
                //axle.right.brakeTorque = 100;
                ////continue;
                axle.left.wheelDampingRate = 100;
                axle.right.wheelDampingRate = 100;
            }
            else
            {
                axle.left.wheelDampingRate = 1;
                axle.right.wheelDampingRate = 1;
                //axle.left.brakeTorque = 0;
                //axle.right.brakeTorque = 0;
            }

            if (axle.motor)
            {
                axle.left.motorTorque = motorTorque;
                axle.right.motorTorque = motorTorque;
            }

            UpdateWheels(axle);
        }

        //can use wheel damping as brakes
        rpmCounter.GetComponent<TMPro.TextMeshProUGUI>().text = Math.Round(MeterSecondToKPH(GetSpeed(axles[0].left))).ToString() + " KM/H";
    }

    private void UpdateWheelPosition(WheelCollider collider, Transform wheelTransform)  
    {
        Vector3 pos;
        Quaternion rot;
        collider.GetWorldPose(out pos, out rot);
        wheelTransform.position = pos;
        wheelTransform.rotation = rot;
    }

    private void UpdateWheels(Axle axle)
    {
        UpdateWheelPosition(axle.left, axle.leftWheelTransform);
        UpdateWheelPosition(axle.right, axle.rightWheelTransform);
    }

    private double GetSpeed(WheelCollider wheel)
    {
        float rps = wheel.rpm / 60.0f;
        double anglurVelocity = rps * 2 * Math.PI;
        double velocity = anglurVelocity * wheel.radius;
        return velocity; // returns in m/s
    }

    private double MeterSecondToKPH(double velocity)
    {
        return velocity / 1000.0 * 3600.0;
    }
}
