using System.Collections;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] private List<Axle> axles;
    [SerializeField] private float maxSteeringAngle = 20;
    [SerializeField] private float maxMotorTorque = 400;
    [SerializeField] private GameObject rpmCounter;

    private float steering;
    private float motorTorque;

    private bool brake = false;


    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(rpmCounter.GetComponent<TMPro.TextMeshProUGUI>().text);
    }

    // Update is called once per frame
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
            float 
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
                axle.left.wheelDampingRate = 100;
            }
            else
            {
                //axle.left.brakeTorque = 0;
                //axle.right.brakeTorque = 0;
            }

            if (axle.motor)
            {
                axle.left.motorTorque = motorTorque;
                axle.right.motorTorque = motorTorque;
            }
        }

        //can use wheel damping as brakes
        rpmCounter.GetComponent<TMPro.TextMeshProUGUI>().text = "RPM: " + Math.Round(axles[1].left.rpm, 2).ToString();
    }
}
