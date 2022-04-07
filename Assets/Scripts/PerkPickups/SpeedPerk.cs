using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class SpeedPerk : MonoBehaviour
{
    public GameObject PerkUI;
    public GameObject player;
    public GameObject BrokeBoiUI;
    public float PerkCost = 2750f;
    bool triggered = false;
    public AudioSource Purchased;

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
        CharacterC characterC = player.GetComponent<CharacterC>();

        if (PerkCost <= Charactercash.Cash)
        {
            Charactercash.TakeCash(PerkCost);
            characterC.playerSettings.RunningForwardSpeed = 8.5f;
            characterC.playerSettings.RunningStrafeSpeed = 5.5f;
            characterC.playerSettings.WalkingForwardSpeed = 6.5f;
            characterC.playerSettings.WalkingStrafeSpeed = 3.5f;
            characterC.playerSettings.WalkingBackwardsSpeed = 2.5f;
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
        Destroy(gameObject);
    }
}
