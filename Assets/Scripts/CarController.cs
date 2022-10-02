using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] private List<Axle> axles;
    [SerializeField] private float maxSteeringAngle = 20;
    [SerializeField] private float maxMotorTorque = 400;

    private float steering;
    private float motorTorque;

    private bool brake = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //get the input
        steering = Input.GetAxis("Horizontal") * maxSteeringAngle;
        motorTorque = Input.GetAxis("Vertical") * maxMotorTorque;

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
            if (axle.steering)
            {
                axle.left.steerAngle = steering;
                axle.right.steerAngle = steering;
            }

            if (brake)
            {
                Debug.Log("Braking");
                axle.left.brakeTorque = 100;
                axle.right.brakeTorque = 100;
                //continue;
            }
            //else
            //{
            //    axle.left.brakeTorque = 0;
            //    axle.right.brakeTorque = 0;
            //}

            if (axle.motor)
            {
                axle.left.motorTorque = motorTorque;
                axle.right.motorTorque = motorTorque;
            }
        }
    }
}
