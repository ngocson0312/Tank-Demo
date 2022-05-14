using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//trong vòng tròn đó giúp cho tháp pháo enemy xoay xung quanh và tìm đc tank nếu nằm trong phạm vi
public class AIPatrolStaticBehaviour : AIBehaviour
{
    public float patrolDelay = 4;// thời gian delay giữa các lần tuần tra

    [SerializeField]
    private Vector2 randomDirection = Vector2.zero;//hướng ngẫu nhien mà họng pháo xoay
    [SerializeField]
    private float currentPatrolDelay;//độ trễ hiện tại

    private void Awake()
    {
        randomDirection = Random.insideUnitCircle;//trả về 1 điểm ngẫu nhiên bên trong vòng tròn đó
    }

    //trong vòng tròn đó giúp cho tháp pháo enemy xoay xung quanh và tìm đc tank nếu nằm trong phạm vi
    public override void PerformAction(TankController tank, AIDetector detector)
    {
        //tính toán góc (tại vì mk đang để nòng pháo bên phải trong unity)
        float angle = Vector2.Angle(tank.AinTurret.transform.right, randomDirection);
        if (currentPatrolDelay <= 0 && (angle < 2))
        {
            randomDirection = Random.insideUnitCircle;
            currentPatrolDelay = patrolDelay;
        }
        else
        {
            if (currentPatrolDelay > 0)
                currentPatrolDelay -= Time.deltaTime;
            else
                tank.HandleTuretMovement((Vector2)tank.AinTurret.transform.position + randomDirection);
        }
    }
}
