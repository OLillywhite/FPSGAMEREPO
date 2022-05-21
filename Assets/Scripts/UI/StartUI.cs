using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUI : MonoBehaviour
{
    public GameObject UICube;
    public GameObject HUDUI;
    public GameObject PerkUI;
    public GameObject WaveUI;
    public GameObject Canvas;
    public GameObject Startstuff;
    public Animator Canvasanim;
    public GameObject txtobj;

    public void Awake()
    {
        Canvasanim = Canvas.GetComponent<Animator>();
    }
    void Start()
    {
        Time.timeScale = 0f;
        PauseMenu.GameIsPaused = true;
        TimeTrig.GameIsOver = true;
    }

    public void Gamestart()
    {
        txtobj.SetActive(false);
        Time.timeScale = 1f;
        PauseMenu.GameIsPaused = false;
        UICube.SetActive(true);
        HUDUI.SetActive(true);
        PerkUI.SetActive(true);
        WaveUI.SetActive(true);
        Startstuff.SetActive(false);
        Canvasanim.SetBool("GameStart", true);
        TimeTrig.GameIsOver = false;
    }
}
