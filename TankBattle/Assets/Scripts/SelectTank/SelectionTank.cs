using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SelectionTank : MonoBehaviour
{
    public GameObject[] tanklist;
    public int selectedtank = 0;

    public void NextTank()
    {
        tanklist[selectedtank].SetActive(false);
        selectedtank = (selectedtank + 1) % tanklist.Length;
        tanklist[selectedtank].SetActive(true);
    }
    public void PreviousTank()
    {
        tanklist[selectedtank].SetActive(false);
        selectedtank--;
        if (selectedtank < 0)
        {
            selectedtank += tanklist.Length;
        }
        tanklist[selectedtank].SetActive(true);
    }
    public void StartGame()
    {
        PlayerPrefs.SetInt("selectedtank", selectedtank);
        Time.timeScale = 1f;
        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }
}
