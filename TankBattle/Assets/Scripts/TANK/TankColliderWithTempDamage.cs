using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankColliderWithTempDamage : MonoBehaviour
{
    public static TankColliderWithTempDamage instance;
    public static bool isBulletTempDamage;

    private void Awake()
    {
        instance = this;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.tag == "BulletMaxDamage")
        {
            Debug.Log("time bullet");
            isBulletTempDamage = true;
            Destroy(collision.gameObject);
            //StartCoroutine(timeBulletDamage());

        }


    }

    IEnumerator timeBulletDamage()
    {

        yield return new WaitForSeconds(5f);
        isBulletTempDamage = false;
    }
}
