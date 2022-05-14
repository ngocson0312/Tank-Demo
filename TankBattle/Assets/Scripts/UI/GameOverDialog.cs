using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverDialog : Dialog
{
   // public GameObject canvas;
    public override void Show(bool isShow)
    {
        Time.timeScale = 0f;
        base.Show(isShow);
    }

    public void HomeBtn()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main");
    }

    public void ExitBtn()
    {
        Time.timeScale = 1f;
        Application.Quit();
    }

    public void ReplayBtn()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("LV00");
        //canvas.SetActive(false);
    }

    public void Replay01Btn()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(3, LoadSceneMode.Single);
    }
    public void Replay02Btn()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(4, LoadSceneMode.Single);
    }
}
