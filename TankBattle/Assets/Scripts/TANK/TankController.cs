using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    public static TankController instance;
    public TankMover TankMover;
    public AimTurret AinTurret;
    public Turret Turrets;


    public static bool isBullet02;

    public static int index;

    float timeDown = 5;
    private void Awake()
    {
        index = 0;
        instance = this;

        if(TankMover == null)
        {
            TankMover = GetComponentInChildren<TankMover>();
        }

        if (AinTurret == null)
        {
            AinTurret = GetComponentInChildren<AimTurret>();
        }

        if(Turrets == null )
        {
            Turrets = GetComponentInChildren<Turret>();
        }
    }




    // xử lý bắn
    public void HandleShoot()
    {
        Turrets.Shoot();
    }

    //xử lý di chuyển
    public void HandleMoveBody(Vector2 movementVecter)
    {
        TankMover.Move(movementVecter);
    }


    // xử lý trực pháo
    public void HandleTuretMovement(Vector2 PointPosition)
    {
        AinTurret.Aim(PointPosition);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       

        if (collision.gameObject.tag == "Bullet02")
        {
            isBullet02 = true;
            Debug.Log("done");
            index = 1;
            //ChangeIndex();
            Destroy(collision.gameObject);
            Debug.Log(index);
            StartCoroutine(time());
            
        }

    }

    IEnumerator time ()
    {
        yield return new WaitForSeconds(8f);
        index = 0;
        isBullet02 = false;
        Debug.Log(index);
    }

    
}
