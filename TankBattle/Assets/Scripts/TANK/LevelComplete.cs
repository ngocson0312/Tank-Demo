using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComplete : MonoBehaviour
{
    int count = 0;
    public int Enemy = 0;
    public GameObject WinDialog;

    public void Count()
    {
        count++;
        Debug.Log("ABBCBBCUJJJJJJJJJJJJJJJ");
        if(count == Enemy)
        {
            WinDialog.SetActive(true);
            Time.timeScale = 0f;
        }    
    }    
}
