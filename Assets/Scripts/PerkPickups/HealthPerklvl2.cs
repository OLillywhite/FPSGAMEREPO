using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class HealthPerklvl2 : MonoBehaviour
{
    public GameObject PerkUI;
    public GameObject player;
    public GameObject BrokeBoiUI;
    public float PerkCost = 5000f;
    bool triggered = false;
    public AudioSource Purchased;
    //public GameObject lvl3obj;

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
            BrokeBoiUI.SetActive(false);
        }
    }

    void Purchase()
    {
        CharacterCash Charactercash = player.GetComponent<CharacterCash>();
        CharacterHealth Characterhealth = player.GetComponent<CharacterHealth>();

        if (PerkCost <= Charactercash.Cash)
        {
            Charactercash.TakeCash(PerkCost);
            Characterhealth.MaxHealth = 200f;
            Characterhealth.health = Characterhealth.MaxHealth;
            Pickup();
        }

        else
        {
            BrokeBoiUI.SetActive(true);
            PerkUI.SetActive(false);
        }

    }

    void Pickup()
    {
        PerkUI.SetActive(false);
        Purchased.Play();
        //lvl3obj.SetActive(true);
        Destroy(gameObject);
    }
}