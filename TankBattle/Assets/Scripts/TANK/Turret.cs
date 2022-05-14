using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof( ObjectPool))]
public class Turret : MonoBehaviour
{
    public static Turret instance;
    //class này phụ trách bắn đạn 
    public List<Transform> turretBarrels;
    public TurretData[] turretData;

    bool canShoot = true;
    Collider2D[] tankColliders;
    float currentDelay = 0;

    private ObjectPool bulletPool;
    [SerializeField]
    private int bulletPoolCount = 2;//số lượng nhóm đạn

    public UnityEvent OnShoot, OnCantShoot;
    public UnityEvent<float> OnReloading;

    public LayerMask layerMask;

    private void Awake()
    {
        instance = this;
        tankColliders = GetComponentsInParent<Collider2D>();
        bulletPool = GetComponent<ObjectPool>();
    }

    private void Start()
    {

        //khởi tạo danh sách các đạn khi chạy chương trình
        
        Bullet02(TankController.index);
        //bulletPool.Initialize(turretData[Damagable.index].bulletPrefab, bulletPoolCount);
        OnReloading?.Invoke(currentDelay);
    }

    public void Bullet02(int index)
    {

        
        bulletPool.Initialize(turretData[index].bulletPrefab, bulletPoolCount);
 
       
    }    

    private void Update()
    {
        Bullet02(TankController.index);

        if (canShoot == false)
        {
            currentDelay -= Time.deltaTime;
            OnReloading?.Invoke(currentDelay/ turretData[TankController.index].reloadDelay);
            if (currentDelay<=0)
            {
                canShoot = true;
            }
        }

       // RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, 20, layerMask);
        

        if (TankColliderWithTempDamage.isBulletTempDamage == true)
        {
            turretData[0].bulletData.damage = 50;

        }
        else
        {
            turretData[0].bulletData.damage = 20;
        }


    }
    public void Shoot()
    {
        if(canShoot)
        {
            canShoot = false;
            currentDelay = turretData[TankController.index].reloadDelay;
            foreach (var barrel in turretBarrels)
            {
                var hit = Physics2D.Raycast(barrel.position, barrel.up);
                if (hit.collider != null)
                    Debug.Log(hit.collider.name);
                //GameObject bullet = Instantiate(bulletPrefab);
                GameObject bullet = bulletPool.CreateObject();
                bullet.transform.position = barrel.position;
                bullet.transform.localRotation = barrel.rotation;
                bullet.GetComponent<Bullet>().Intialize();

                foreach (var collider in tankColliders)
                {
                    Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), collider);
                }

            }
            OnShoot?.Invoke();
            OnReloading?.Invoke(currentDelay);
        }
        else
        {
            OnCantShoot?.Invoke();
        }
    }
}
