using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//xử dụng cho explosion
public class ObjectGeneratorRandomPositionUtil : MonoBehaviour
{
    public GameObject objectPrefab;//đối tượng explosion

    public float radius = 0.2f;//phạm vi thực hiện animation

    //lấy vị trí ngẫu nhiên
    protected Vector2 GetRandomPosition()
    {
        return Random.insideUnitCircle * radius + (Vector2)transform.position;
    }


    //cho phép quay ngẫu nhiên 
    protected Quaternion Random2DRotation()
    {
        return Quaternion.Euler(0, 0, Random.Range(0, 360));
    }


    //tạo ra đối tượng hoạt ảnh explosion
    public void CreteObject()
    {
        Vector2 position = GetRandomPosition();
        GameObject impactObject = GetObject();
        impactObject.transform.position = position;
        impactObject.transform.rotation = Random2DRotation();
    }

    protected virtual GameObject GetObject()
    {
        return Instantiate(objectPrefab);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
