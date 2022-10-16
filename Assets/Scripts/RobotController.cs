using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public enum RotationDir { None = 0, Pos = 1, Neg = -1}
public class RobotController : MonoBehaviour
{

    private ArticulationBody articulation;
    [SerializeField] private float speed = 300.0f;

    private float horizontal = 0.0f;
    private RotationDir rotationDir = RotationDir.None;
    private void Start()
    {
       articulation = GetComponent<ArticulationBody>();
    }

    private void FixedUpdate()
    {
        horizontal = Input.GetAxis("Horizontal");
        
        if (horizontal == 0.0f)
        {
            rotationDir = RotationDir.None; 
        }
        else if (horizontal > 0.0f)
        {
            rotationDir = RotationDir.Pos;
        }
        else if (horizontal < 0.0f)
        {
            rotationDir = RotationDir.Neg;
        }

        float currentRotation = CurrentPrimaryAxisRotation();
        float rotationGoal = currentRotation + (speed * Time.fixedDeltaTime) * (int)rotationDir;
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
