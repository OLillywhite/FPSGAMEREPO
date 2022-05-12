using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class ElectricityEnable : MonoBehaviour
{
    public GameObject PerkUI;
    public GameObject player;
    public GameObject BrokeBoiUI;
    public float PerkCost = 5000f;
    bool triggered = false;
    public AudioSource Purchased;
    public bool ElectricityOn = false;
    public GameObject LightOBJ;
    public GameObject OnOBJ;

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
        
        if (PerkCost <= Charactercash.Cash)
        {
            Charactercash.TakeCash(PerkCost);
            ElectricityOn = true;
            LightOBJ.SetActive(true);
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
        OnOBJ.SetActive(true);
        Destroy(GetComponent("SphereCollider"));
        triggered = false;
    }
}
