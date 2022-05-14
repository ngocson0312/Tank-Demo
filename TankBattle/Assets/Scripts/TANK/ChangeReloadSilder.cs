using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeReloadSilder : MonoBehaviour
{
    public Sprite ReloadSilderOriginal;
    public Sprite ReloadSilderSpeed;
    private void Update()
    {


        if (TankController.isBullet02 == true)
        {
            this.gameObject.GetComponent<Image>().sprite = ReloadSilderSpeed;
        }
        else
        {
            this.gameObject.GetComponent<Image>().sprite = ReloadSilderOriginal;
        }
    }
}
