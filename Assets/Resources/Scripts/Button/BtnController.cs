using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BtnController : MonoBehaviour
{
    public GameObject MenuMusic;
    public GameObject SettingPannel;
    public void Play()
    {
        SoundController.Instance.PlayThisSong("ClickBtn", 0.5f);
        SceneManager.LoadScene(1);
    }

    public void Back()
    {
        SceneManager.LoadScene(0);
        SoundController.Instance.PlayThisSong("ClickBtn", 0.5f);    
    }

    public void Reset()
    {
        SceneManager.LoadScene(1);
    }

    public void Close()
    {
        Application.Quit();
    }

    public void Image()
    {
        SoundController.Instance.PlayThisSong("ClickBtn", 0.5f);
        MenuMusic.SetActive(true);
    }

    bool music = true;
    public void Music()
    {
        SoundController.Instance.PlayThisSong("ClickBtn", 0.5f);
        if (music) 
        {
            AudioController.Instance.audioSource.volume = 0;
            music = !music;
        }
        else
        {
            AudioController.Instance.audioSource.volume = 0.5f;
            music = !music;
        }

    }

    public void CloseSetting()
    {
        SoundController.Instance.PlayThisSong("ClickBtn", 0.5f);
        SettingPannel.SetActive(false);
    }


}
