using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Slider volumeslider;
    public GameObject SettingWindow;
    void Start()
    {
        if (!PlayerPrefs.HasKey("musicvolume"))
        {
            PlayerPrefs.SetFloat("musicvolume", 1);
            load();
        }
    }

    public void changevolum()
    {
        AudioListener.volume = volumeslider.value;
    }

    private void load()
    {
        volumeslider.value = PlayerPrefs.GetFloat("musicvolume");
    }
    private void save()
    {
        PlayerPrefs.SetFloat("musicvolume", volumeslider.value);
    }
    public void back()
    {
        SettingWindow.SetActive(false);
    }
}
