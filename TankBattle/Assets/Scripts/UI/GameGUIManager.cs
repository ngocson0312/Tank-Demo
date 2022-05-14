using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGUIManager : MonoBehaviour
{
    public PauseDialog PauseDialog;
    public WinDialog WinDialog;
    public GameOverDialog GameOverDialog;
    public void PauseGame()
    {
        if(PauseDialog)
        {
            PauseDialog.Show(true);
        }
    }

    public void GameOver()
    {
        if (GameOverDialog)
        {
            GameOverDialog.Show(true);
        }
    }

    public void isGameOver()
    {
        if(Damagable.isDie ==true)
        {
            GameOver();
        }    
    }    
}
