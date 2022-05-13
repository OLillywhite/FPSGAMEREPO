using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class TimeTrig : MonoBehaviour
{
    public GameObject PerkUI;
    public GameObject player;
    bool triggered = false;
    public AudioSource TimeSound;

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
        Pickup();      
    }

    void Pickup()
    {
        PerkUI.SetActive(false);
        TimeSound.Play();
    }
}
