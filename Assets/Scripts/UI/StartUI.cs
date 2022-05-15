using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUI : MonoBehaviour
{
    public GameObject UICube;
    public GameObject HUDUI;
    public GameObject PerkUI;
    public GameObject WaveUI;

        void Start()
    {
        Time.timeScale = 0f;
        PauseMenu.GameIsPaused = true;
    }

    public void Gamestart()
    {
        Time.timeScale = 1f;
        PauseMenu.GameIsPaused = false;
        UICube.SetActive(true);
        HUDUI.SetActive(true);
        PerkUI.SetActive(true);
        WaveUI.SetActive(true);
        Destroy(gameObject);
    }
}
