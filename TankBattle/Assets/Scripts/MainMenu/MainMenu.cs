using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public GameObject SettingWin;
    public GameObject Guide;
    public void PlayGame()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
    public void Quit()
    {
        Application.Quit();
    }
    
    public void Setting()
    {
        SettingWin.SetActive(true);
    }

    public void guide()
    {
        Guide.SetActive(true);
    }

    public void backGui()
    {
        Guide.SetActive(false);
    }
}
