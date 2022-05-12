using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class DoorOpenMech : MonoBehaviour
{
    public GameObject PerkUI;
    public GameObject player;
    bool triggered = false;

    public GameObject door;
    public Animator dooranimator;


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
        }
    }


    void Purchase()
    {
        bool myVal = dooranimator.GetBool("DoorOpen");
        if (myVal== false)
        {
          dooranimator.SetBool("DoorOpen", true);
        }
            
        else
        {
            dooranimator.SetBool("DoorOpen", false);
        }
    
    }

    
}