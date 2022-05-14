using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bullet : MonoBehaviour
{
    public BulletData BulletData;

    public Sprite bulletOriginal;
    public Sprite bulletSpeed;
    

    Vector2 startPosition;
    float conquaredDistance = 0;// khoảng cách chinh phục
    Rigidbody2D rb;

    public UnityEvent OnHit = new UnityEvent();
    public static Bullet instance;
    private void Awake()
    {
        instance = this;
        rb = GetComponent<Rigidbody2D>();
    }

    public void Intialize()
    {
        startPosition = transform.position;
        rb.velocity = transform.up * BulletData.speed;
    }

    private void Update()
    {
        // tính toán khoảng cách vị trí viên đạn đang bay quay về vị trí lúc đầu
        conquaredDistance = Vector2.Distance(transform.position, startPosition);
        if(conquaredDistance>= BulletData.maxDistance)
        {
            DisableObject();
        }

        if(TankController.isBullet02 ==true)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = bulletSpeed;
        }else
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = bulletOriginal;
        }    
    }

    private void DisableObject()
    {
        rb.velocity = Vector2.zero;
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        OnHit?.Invoke();
        Damagable damagable = collision.GetComponent<Damagable>();
        if (damagable != null)//nếu bị trúng đạn
        {
            damagable.Hit(BulletData.damage);
        }
        DisableObject();
    }
}
