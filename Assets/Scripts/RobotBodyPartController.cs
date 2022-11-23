using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public enum RotationDir { None = 0, Pos = 1, Neg = -1 }
public class RobotBodyPartController : MonoBehaviour
{
    private ArticulationBody articulation;

    private string inputAxis;
    public RotationDir rotation = RotationDir.None;

    public KeyCode posKey;
    public KeyCode negKey;

    public bool useController = false;

    private RobotControls controls;

    private Vector2 move;

    private void Awake()
    {
        controls = new RobotControls();

        controls.RobotMovement.LowerYAxis.performed += ctx => move = ctx.ReadValue<Vector2>();
        //controls.RobotMovement.LowerYAxis.canceled += ctx => move = Vector2.zero;

    }

    private void OnEnable()
    {
        controls.RobotMovement.Enable();
    }


    private void FixedUpdate()
    {
        if (useController)
        {
            Vector2 leftStick = new Vector2(move.x, move.y);
            Debug.Log(leftStick);


            if (leftStick.x > 0)
            {
                rotation = RotationDir.Pos;
            }
            else if (leftStick.x < 0)
            {
                rotation = RotationDir.Neg;
            }
            else
            {
                rotation = RotationDir.None;
            }
        }
        else
        {
            /*
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
            */
        }

        
    }

}
