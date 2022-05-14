using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject TextGUI;
    public bool ispause;
    public static GameManager instance;


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        //textGUI();
    }
    public void textGUI()
    {
        TextGUI.SetActive(true);
        ispause = true;
    }

    public void textGUIFalse()
    {
        TextGUI.SetActive(false);
        ispause = false;
    }
}
