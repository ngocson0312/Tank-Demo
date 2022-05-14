using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//giúp ẩn object muzzleFlash ở nòng tank
public class DisableUtil : MonoBehaviour
{
    public void DisableObject()
    {
        gameObject.SetActive(false);
    }
}
