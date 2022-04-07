using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Medkit : MonoBehaviour
{
    public GameObject PerkUI;
    public GameObject player;
    public GameObject BrokeBoiUI;
    public GameObject Declined;
    public float PerkCost = 1250f;
    bool triggered = false;
    bool decline = false;
    public AudioSource Purchased;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && triggered && !decline)
        {
            Purchase();
        }

        if (Input.GetKeyDown(KeyCode.E) && triggered && decline)
        {
            Declined.SetActive(true);
            return;
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
            Declined.SetActive(false);
            decline = false;
        }
    }

    void Purchase()
    {
        CharacterCash Charactercash = player.GetComponent<CharacterCash>();
        CharacterHealth Characterhealth = player.GetComponent<CharacterHealth>();

        if (Characterhealth.health == Characterhealth.MaxHealth)
        {
           
            PerkUI.SetActive(false);
            decline = true;
        }

        if (PerkCost <= Charactercash.Cash && !decline)
        {
            Charactercash.TakeCash(PerkCost);
            Characterhealth.health = Characterhealth.MaxHealth;
            Pickup();
        }

        if(PerkCost > Charactercash.Cash)
        {
            BrokeBoiUI.SetActive(true);
            PerkUI.SetActive(false);
        }

    }

    void Pickup()
    {
        PerkUI.SetActive(false);
        Purchased.Play();
        //Destroy(gameObject);
    }
}
