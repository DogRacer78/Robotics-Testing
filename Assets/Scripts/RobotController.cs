using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System;


public class RobotController : MonoBehaviour
{

    //private ArticulationBody articulation;
    [SerializeField] private float speed = 300.0f;

    [SerializeField] private Joint[] joints;

    //private RotationDir rotationDir = RotationDir.None;
    private void Start()
    {
       //articulation = GetComponent<ArticulationBody>();
    }

    private void FixedUpdate()
    {

        
        /*
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
        */

        foreach (Joint part in joints)
        {
            if (part.part.GetComponent<RobotBodyPartController>().rotation != RotationDir.None)
            {
                ArticulationBody articulation = part.part.GetComponent<ArticulationBody>();
                float currentRotation = CurrentPrimaryAxisRotation(articulation);
                float rotationGoal = currentRotation + (speed * Time.fixedDeltaTime) * (int)part.part.GetComponent<RobotBodyPartController>().rotation;
                //rotationGoal = Mathf.Round(rotationGoal);
                RotateTo(rotationGoal, articulation);

                //Debug.Log(rotationGoal);
            }

        }

        
    }

    float CurrentPrimaryAxisRotation(ArticulationBody articulation)
    {
        float rads = articulation.jointPosition[0];
        float currentRotation = Mathf.Rad2Deg * rads;
        return currentRotation;
    }

    void RotateTo(float primaryAxisRotation, ArticulationBody articulation)
    {
        var drive = articulation.xDrive;
        drive.target = primaryAxisRotation;
        Debug.Log("xDrive " + articulation.xDrive.target);
        articulation.xDrive = drive;
    }

}

[Serializable]
public struct Joint
{
    public GameObject part;
}