using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GripperController : MonoBehaviour
{

    private ArticulationBody art;
    private float speed = 100.0f;
    public bool invert = false;
    // Start is called before the first frame update
    void Start()
    {
        art = GetComponent<ArticulationBody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /*
        if (Input.GetKey(KeyCode.K))
        {
            float currentRotation = CurrentPrimaryAxisRotation(art);
            float rotationGoal = 0.0f;
            if (invert)
            {
                rotationGoal = currentRotation + (speed * Time.fixedDeltaTime) * -1;
            }
            else
            {
                rotationGoal = currentRotation + (speed * Time.fixedDeltaTime) * 1;
            }
            
            RotateTo(rotationGoal, art);
        }
        else if (Input.GetKey(KeyCode.J))
        {
            float currentRotation = CurrentPrimaryAxisRotation(art);
            float rotationGoal = 0.0f;
            if (invert)
            {
                rotationGoal = currentRotation + (speed * Time.fixedDeltaTime) * 1;
            }
            else
            {
                rotationGoal = currentRotation + (speed * Time.fixedDeltaTime) * -1;
            }
            RotateTo(rotationGoal, art);
        }
        */
        
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
