using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//scripts viết cho khi mà đạn va chạm thì âm thanh sẽ được phát ra thôi
public class InstantiateUtil : MonoBehaviour
{
    public GameObject objectToinstantiate;//impactSound

    public void InstantiateObject()
    {
        Instantiate(objectToinstantiate);
    }
}
