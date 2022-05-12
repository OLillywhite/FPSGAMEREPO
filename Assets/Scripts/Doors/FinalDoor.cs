using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class FinalDoor : MonoBehaviour
{
    public GameObject PerkUI;
    public GameObject player;
    public GameObject BrokeBoiUI;
    public float PerkCost = 30000f;
    bool triggered = false;
    public AudioSource Purchased;
    public GameObject door;
    public Animator dooranimator;

    public GameObject OpenMech;


    public void Awake()
    {
        dooranimator = door.GetComponent<Animator>();
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

            dooranimator.SetBool("DoorOpen", true);
            Charactercash.TakeCash(PerkCost);
            
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
        OpenMech.SetActive(true);
    }
}