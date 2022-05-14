using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinDialog : Dialog
{
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

    public void NextLVBtn()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("LV01");
    }

    public void NextLV02Btn()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("LV02");
    }

    public void ReplayBtn()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("LV00");
    }

    public void Replay01Btn()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("LV01");
    }

    public void Replay02Btn()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("LV02");
    }
}
