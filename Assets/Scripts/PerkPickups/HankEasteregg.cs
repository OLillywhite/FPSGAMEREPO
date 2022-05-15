using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class HankEasteregg : MonoBehaviour
{
    public GameObject PerkUI;
    public GameObject player; 
    public AudioSource Audioclip;
    public GameObject WaltEasterEgg;

    public float CashGive;

    public bool triggered = false;

   
    void start()
    {
        this.Audioclip.playOnAwake = false;
    }
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
            PerkUI.SetActive(false);
            triggered = false;
        }
    }

    void Purchase()
    {
        CharacterCash Charactercash = player.GetComponent<CharacterCash>();
        
            Charactercash.AddCash(CashGive);
            Charactercash.AddTotalCash(CashGive);
            Pickup();

    }

    void Pickup()
    {
        Audioclip.Play();
        Destroy(gameObject);
        PerkUI.SetActive(false);
        WaltEasterEgg.SetActive(true);
    }
}
