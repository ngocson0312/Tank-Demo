using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//giúp cho lô cốt bắn tank
public class AiShootBehaviour : AIBehaviour
{
    public float fieldOfVisionForShooting = 60;//tầm nhìn để bắn

    public override void PerformAction(TankController tank, AIDetector detector)
    {
        if (TargetInFOV(tank, detector))
        {
            tank.HandleMoveBody(Vector2.zero);//giúp cho việc ngăn di chuyển khi bắn
            tank.HandleShoot();
        }

        tank.HandleTuretMovement(detector.Target.position);//di chuyển
    }

    //kiểm tra xem tank có ở trong tầm nhìn không
    private bool TargetInFOV(TankController tank, AIDetector detector)
    {
        //tìm hướng
        var direction = detector.Target.position - tank.AinTurret.transform.position;
        if (Vector2.Angle(tank.AinTurret.transform.right, direction) < fieldOfVisionForShooting / 2)//tính góc
        {
            return true;
        }
        return false;
    }
}
