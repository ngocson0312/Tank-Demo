using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewTurretData", menuName = "Data/TurretData")]
public class TurretData : ScriptableObject
{
    public static TurretData instance;
    private void Awake()
    {
        instance = this;
    }

    public GameObject bulletPrefab;
    public float reloadDelay = 1;
    public BulletData bulletData;
}
