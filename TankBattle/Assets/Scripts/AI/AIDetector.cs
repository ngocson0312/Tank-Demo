using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//lớp này xử lý việc phạm vi bắn của lô cốt và không bắn đc tank nếu tank nấp sau chướng ngại vật trong phạm vi bắn của  lô cốt
public class AIDetector : MonoBehaviour
{
    [Range(1, 15)]
    [SerializeField]
    private float viewRadius = 11;//phạm vi phát hiện
    [SerializeField]
    private float detectionCheckDelay = 0.1f;//độ trễ kiểm tra phát hiện
    [SerializeField]
    private Transform target = null;//đối tượng tấn công (player)
    [SerializeField]
    private LayerMask playerLayerMask;
    [SerializeField]
    private LayerMask visibilityLayer;//giúp cho việc nếu player trốn sau các lớp này thì sẽ làm cho lô cốt không tấn công

    [field: SerializeField]
    public bool TargetVisible { get; private set; }
    public Transform Target
    {
        get => target;
        set
        {
            target = value;
            TargetVisible = false;
        }
    }

    private void Start()
    {
        StartCoroutine(DetectionCoroutine());
    }

    private void Update()
    {
        if (Target != null)
            TargetVisible = CheckTargetVisible();
    }

    //giúp kiểm tra đc các chướng ngại vật thì không bắn được nếu tank đứng sau
    private bool CheckTargetVisible()
    {
        var result = Physics2D.Raycast(transform.position, Target.position - transform.position, viewRadius, visibilityLayer);
        if (result.collider != null)
        {
            return (playerLayerMask & (1 << result.collider.gameObject.layer)) != 0;
        }
        return false;
    }

    //phát hiện mục tiêu
    private void DetectTarget()
    {
        if (Target == null)
            CheckIfPlayerInRange();//kiểm tra xem người chơi có trong tầm bắn hay không
        else if (Target != null)
            DetectIfOutOfRange();//người chơi rời khỏi tầm bắn
    }

    //xác định được người chơi rời khỏi tầm bắn 
    private void DetectIfOutOfRange()
    {
        if (Target == null || Target.gameObject.activeSelf == false || Vector2.Distance(transform.position, Target.position) > viewRadius + 1)
        {
            Target = null;
        }
    }

    //kiểm tra xem người chơi có trong tầm bắn hay không
    private void CheckIfPlayerInRange()
    {
        Collider2D collision = Physics2D.OverlapCircle(transform.position, viewRadius, playerLayerMask);
        if (collision != null)
        {
            Target = collision.transform;
        }
    }

    // thời gian lặp lại để cho lô cốt phát hiện (cho lô cốt phát hiện nhiều lần)
    IEnumerator DetectionCoroutine()
    {
        yield return new WaitForSeconds(detectionCheckDelay);
        DetectTarget();
        StartCoroutine(DetectionCoroutine());

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, viewRadius);
    }
}
