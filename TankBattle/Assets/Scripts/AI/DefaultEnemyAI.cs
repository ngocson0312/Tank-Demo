using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DefaultEnemyAI : MonoBehaviour
{
    [SerializeField]
    private AIBehaviour shootBehaviour, patrolBehaviour;

    [SerializeField]
    private TankController tank;
    [SerializeField]
    private AIDetector detector;

    private void Awake()
    {
        detector = GetComponentInChildren<AIDetector>();
        tank = GetComponentInChildren<TankController>();
    }

    private void Update()
    {
        if (detector.TargetVisible)//nếu phát hiện mục tiêu thì bắn
        {
            shootBehaviour.PerformAction(tank, detector);
        }
        else// không thì thôi
        {
            patrolBehaviour.PerformAction(tank, detector);
        }
    }
}
