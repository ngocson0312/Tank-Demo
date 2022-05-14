using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimTurret : MonoBehaviour
{
    //class này phụ trách xoay trục súng
    public float turretRotationSpeed = 150;
    public void Aim(Vector2 inputPointPositon)
    {
        //tính toán khoảng cách từ vt  đến vị trí bắn
        var turretDirection = (Vector3)inputPointPositon - transform.position;
        var DesiredAngle = Mathf.Atan2(turretDirection.y, turretDirection.x) * Mathf.Rad2Deg; // tính toán góc mong muốn

        //cho vòng xoay mượt 
        var rotationStep = turretRotationSpeed * Time.deltaTime;

        //xoay trục pháo
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, DesiredAngle), rotationStep);
    }
}
