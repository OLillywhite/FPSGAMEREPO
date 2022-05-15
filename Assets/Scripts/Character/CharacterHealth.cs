using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    public float health = 100f;
    public GameObject DeathUI;
    public GameObject HealthUI;
    public GameObject player;
    public GameObject UICube;
    public GameObject WaveUI;
    public GameObject HUDUI;
    public GameObject GameOverUI;
    public GameObject GameOverTXT;
    public float MaxHealth = 100f;

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
        if (health <= 0f)
        {
            health = 0f;
        }

    }

    public void Die()
    {
        DeathUI.SetActive(true);
        HealthUI.SetActive(false);
        UICube.SetActive(false);
        WaveUI.SetActive(false);
        HUDUI.SetActive(false);
        GameOverUI.SetActive(false);
        GameOverTXT.SetActive(true);
        PauseMenu.GameIsPaused = true;
        TimeTrig.GameIsOver = true;
        Time.timeScale = 0f;
    }
}
