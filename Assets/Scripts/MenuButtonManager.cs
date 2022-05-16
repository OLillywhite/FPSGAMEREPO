using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuButtonManager : MonoBehaviour
{
    public GameObject GameStartUI;
    public GameObject MenuUI;

     public void ClickStart()
     {
        GameStartUI.SetActive(false);
        MenuUI.SetActive(true);
     }

    public void PlayGame()
    {
        Debug.Log("Loading Game...");
        SceneManager.LoadScene("GigaChadScene");
    }

    public void InfoScene()
    {
        Debug.Log("Loading Info...");
        SceneManager.LoadScene("Info");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }
}
