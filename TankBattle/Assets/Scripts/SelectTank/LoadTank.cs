using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadTank : MonoBehaviour
{
    public static LoadTank instance;
    public GameObject[] tankPrefabs;
    public Transform spawnPoint;
    
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        
        int selectedtank = PlayerPrefs.GetInt("selectedtank");
        GameObject prefab = tankPrefabs[selectedtank];
        GameObject clone = Instantiate(prefab, spawnPoint.position, Quaternion.identity);
        clone.SetActive(true);
    }
    
    
    
}
