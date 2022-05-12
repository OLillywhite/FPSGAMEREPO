using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class TimeDoorPurchase : MonoBehaviour
{
    public GameObject PerkUI;
    public GameObject player;
    public GameObject ElectricityOBJ;
    public GameObject BrokeBoiUI;
    public GameObject NoElectricityUI;
    public float PerkCost = 5000f;
    bool triggered = false;
    public AudioSource Purchased;
    public GameObject door;
    public Animator dooranimator;

    public GameObject TimeMachine;

    public void Awake()
    {
        dooranimator = door.GetComponent<Animator>();
    }

    void Update()
    {

        ElectricityEnable Electricityenable = ElectricityOBJ.GetComponent<ElectricityEnable>();

        if (Input.GetKeyDown(KeyCode.E) && triggered && Electricityenable.ElectricityOn)
        {
            Purchase();
        }

        else if (Input.GetKeyDown(KeyCode.E) && triggered && !Electricityenable.ElectricityOn)
        {
            NoElectricityUI.SetActive(true);
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
            NoElectricityUI.SetActive(false);
        }
    }

    void Purchase()
    {
        CharacterCash Charactercash = player.GetComponent<CharacterCash>();

        if (PerkCost <= Charactercash.Cash)
        {

            dooranimator.SetBool("IsPurchased", true);
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
        TimeMachine.SetActive(true);
    }
}
