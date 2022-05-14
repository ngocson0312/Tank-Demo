using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="NewTankMovementData", menuName = "Data/TankMovementData")]
public class TankMovementDate : ScriptableObject
{
    public float maxSpeed = 10;
    public float RotationSpeed = 100;
    public float Acceleration = 70;//sự tăng tốc
    public float Deacceleration = 50;//sự giảm tốc


}
