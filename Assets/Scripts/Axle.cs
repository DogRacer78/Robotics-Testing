using System;
using UnityEngine;

[Serializable]
public class Axle
{
    public WheelCollider left;
    public WheelCollider right;
    public bool motor;
    public bool steering;
}