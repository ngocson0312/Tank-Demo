using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPatrolPathBehaviour : AIBehaviour
{
    public PatrolPath patrolPath; //các đường tuần tra
    [Range(0.1f, 1)]
    public float arriveDistance = 1;//khoảng cách đến
    public float waitTime = 0.5f;//tg chờ
    [SerializeField]
    private bool isWaiting = false;
    [SerializeField]
    Vector2 currentPatrolTarget = Vector2.zero;
    bool isInitialized = false;//khởi tạo tank Ai 

    private int currentIndex = -1;

    private void Awake()
    {
        if (patrolPath == null)
            patrolPath = GetComponentInChildren<PatrolPath>();
    }

    public override void PerformAction(TankController tank, AIDetector detector)
    {
        if (!isWaiting)
        {
            if (patrolPath.Length < 2)
                return;
            if (!isInitialized)
            {
                var currentPathPoint = patrolPath.GetClosestPathPoint(tank.transform.position);
                this.currentIndex = currentPathPoint.Index;
                this.currentPatrolTarget = currentPathPoint.Position;
                isInitialized = true;
            }
            if (Vector2.Distance(tank.transform.position, currentPatrolTarget) < arriveDistance)
            {
                isWaiting = true;
                StartCoroutine(WaitCoroutine());
                return;
            }
            Vector2 directionToGo = currentPatrolTarget - (Vector2)tank.TankMover.transform.position;
            var dotProduct = Vector2.Dot(tank.TankMover.transform.up, directionToGo.normalized);

            if (dotProduct < 0.98f)
            {
                var crossProduct = Vector3.Cross(tank.TankMover.transform.up, directionToGo.normalized);
                int rotationResult = crossProduct.z >= 0 ? -1 : 1;
                tank.HandleMoveBody(new Vector2(rotationResult, 1));
            }
            else
            {
                tank.HandleMoveBody(Vector2.up);
            }

        }

        IEnumerator WaitCoroutine()
        {
            yield return new WaitForSeconds(waitTime);
            var nextPathPoint = patrolPath.GetNextPathPoint(currentIndex);
            currentPatrolTarget = nextPathPoint.Position;
            currentIndex = nextPathPoint.Index;
            isWaiting = false;
        }
    }
}
