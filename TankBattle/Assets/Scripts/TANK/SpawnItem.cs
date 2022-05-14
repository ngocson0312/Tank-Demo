using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour
{
    public List<GameObject> ObjectToSpawn = new List<GameObject>();

    public void Spawnitem()
    {
        int index = Random.Range(0, ObjectToSpawn.Count);
        if(ObjectToSpawn.Count>0)
        {
            Instantiate(ObjectToSpawn[index], transform.position, transform.rotation);

        }
    }    
}
