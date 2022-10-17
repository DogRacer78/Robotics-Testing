using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum RotationDir { None = 0, Pos = 1, Neg = -1 }
public class RobotBodyPartController : MonoBehaviour
{
    private ArticulationBody articulation;

    private string inputAxis;
    public RotationDir rotation = RotationDir.None;

    public KeyCode posKey;
    public KeyCode negKey;

    private void FixedUpdate()
    {
        if (Input.GetKey(posKey))
        {
            rotation = RotationDir.Pos;
        }
        else if (Input.GetKey(negKey))
        {
            rotation = RotationDir.Neg;
        }
        else
        {
            rotation = RotationDir.None;
        }
    }

}
