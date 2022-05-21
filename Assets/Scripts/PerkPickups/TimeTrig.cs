using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class TimeTrig : MonoBehaviour
{
    public GameObject PerkUI;
    public GameObject player;
    bool triggered = false;
    public static bool GameIsOver = false;
    public AudioSource TimeSound;
    public GameObject GameOverUI;
    public GameObject GameCompleteUI;
    public GameObject PauseMenuUI;
    public GameObject UICube;
    public GameObject HUDUI;
    public GameObject WaveUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && triggered)
        {
            Purchase();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            triggered = true;
            PerkUI.SetActive(true);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            triggered = false;
            PerkUI.SetActive(false);

        }
    }

    void Purchase()
    {
        Pickup();      
    }

    void Pickup()
    {
        Time.timeScale = 0f;
        PauseMenuUI.SetActive(false);
        UICube.SetActive(false);
        HUDUI.SetActive(false);
        WaveUI.SetActive(false);
        GameOverUI.SetActive(true);
        GameCompleteUI.SetActive(true);
        PauseMenu.GameIsPaused = true;
        PerkUI.SetActive(false);
        GameIsOver = true;
        TimeSound.Play();
    }
}
