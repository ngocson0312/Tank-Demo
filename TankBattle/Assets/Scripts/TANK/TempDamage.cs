using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempDamage : MonoBehaviour
{
    public TurretData turretData;
    
    void Update()
    {
        if (TankColliderWithTempDamage.isBulletTempDamage == true)
        {
            turretData.bulletData.damage = 50;
        }
        else
        {
            turretData.bulletData.damage = 20;
        }
    }
}
