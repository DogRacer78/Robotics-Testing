using System;
using UnityEngine;

[Serializable]
public class Axle
{
    public WheelCollider left;
    public WheelCollider right;
    public Transform leftWheelTransform;
    public Transform rightWheelTransform;
    public bool motor;
    public bool steering;
}