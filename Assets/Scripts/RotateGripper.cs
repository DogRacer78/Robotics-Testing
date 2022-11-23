using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateGripper : MonoBehaviour
{
    public GameObject movingArm;
    private Transform movingArmTransform = null;
    private ArticulationBody art;
    void Start()
    {
        movingArmTransform = movingArm.GetComponent<Transform>();
        art = this.GetComponent<ArticulationBody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // 
        float rots = -(movingArmTransform.rotation.eulerAngles.x - 270.0f);
        //Debug.Log("Rots: " + (movingArmTransform.rotation.eulerAngles.x - 270.0f));
        RotateTo(-movingArm.GetComponent<ArticulationBody>().xDrive.target, art);
    }

    public void RotateTo(float rotationGoal, ArticulationBody art)
    {
        var drive = art.xDrive;
        drive.target = rotationGoal;
        art.xDrive = drive;
    }
}
