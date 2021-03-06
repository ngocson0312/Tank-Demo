using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//đường tuần tra của AI
public class PatrolPath : MonoBehaviour
{
    public List<Transform> patrolPoints = new List<Transform>();//ds các điểm tuần tra

    public int Length { get => patrolPoints.Count; }//chiều dài của các điểm tuần tra

    [Header("Gizmos parameters")]
    public Color pointsColor = Color.blue;
    public float pointSize = 0.3f;//kích thước điểm
    public Color lineColor = Color.magenta;


    public struct PathPoint
    {
        public int Index;
        public Vector2 Position;
    }

    //giúp Ai nhận điểm gần nhất
    public PathPoint GetClosestPathPoint(Vector2 tankPosition)
    {
        var minDistance = float.MaxValue;
        var index = -1;
        for (int i = 0; i < patrolPoints.Count; i++)
        {
            //tính toán vị trí tank đến điểm gần nhất
            var tempDistance = Vector2.Distance(tankPosition, patrolPoints[i].position);
            if (tempDistance < minDistance)
            {
                minDistance = tempDistance;
                index = i;
            }
        }

        return new PathPoint { Index = index, Position = patrolPoints[index].position };
    }

    // giúp Ai di chuyển đến điểm tiếp theo
    public PathPoint GetNextPathPoint(int index)
    {
        //nếu index +1 lớn hơn số điểm thì trả về 1 nếu không thì index+1
        var newIndex = index + 1 >= patrolPoints.Count ? 0 : index + 1;
        return new PathPoint { Index = newIndex, Position = patrolPoints[newIndex].position };
    }

    //phương thức cho vẽ các điểm (có màu )
    private void OnDrawGizmos()
    {
        if (patrolPoints.Count == 0)
            return;
        for (int i = patrolPoints.Count - 1; i >= 0; i--)
        {
            if (i == -1 || patrolPoints[i] == null)
                return;

            Gizmos.color = pointsColor;
            Gizmos.DrawSphere(patrolPoints[i].position, pointSize);

            if (patrolPoints.Count == 1 || i == 0)
                return;

            Gizmos.color = lineColor;
            Gizmos.DrawLine(patrolPoints[i].position, patrolPoints[i - 1].position);

            if (patrolPoints.Count > 2 && i == patrolPoints.Count - 1)
            {
                Gizmos.DrawLine(patrolPoints[i].position, patrolPoints[0].position);
            }
        }
    }
}
