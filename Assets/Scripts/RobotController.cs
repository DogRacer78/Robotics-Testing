using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotController : MonoBehaviour
{
    private ArticulationBody articulation;
    private void Start()
    {
       articulation = GetComponent<ArticulationBody>();
    }

    private void FixedUpdate()
    {
        float currentRotation = CurrentPrimaryAxisRotation();
        float rotationGoal = currentRotation + (1000.0f * Time.fixedDeltaTime);
        RotateTo(rotationGoal);

        Debug.Log(rotationGoal);
    }

    float CurrentPrimaryAxisRotation()
    {
        float rads = articulation.jointPosition[0];
        float currentRotation = Mathf.Rad2Deg * rads;
        return currentRotation;
    }

    void RotateTo(float primaryAxisRotation)
    {
        var drive = articulation.xDrive;
        drive.target = primaryAxisRotation;
        Debug.Log("xDrive " + articulation.xDrive.target);
        articulation.xDrive = drive;
    }

}
