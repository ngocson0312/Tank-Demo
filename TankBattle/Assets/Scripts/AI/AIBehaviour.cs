using System;
using UnityEngine;

// đây là lớp trừu tượng
public abstract class AIBehaviour:MonoBehaviour
{
    public abstract void PerformAction(TankController tank, AIDetector detector);

}