using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Gunbuff : MonoBehaviour
{
    public GameObject PerkUI;
    public GameObject player;
    public GameObject BrokeBoiUI;
    public float PerkCost = 5000f;
    bool triggered = false;
    public AudioSource Purchased;
    public GameObject GunOBJ;
    public GameObject normalskin;
    public GameObject buffskin;

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
        Gun weaponStats = GunOBJ.GetComponent<Gun>();

        if (Characterhealth.health == Characterhealth.MaxHealth)
        {

            PerkUI.SetActive(false);
        }

        if (PerkCost <= Charactercash.Cash)
        {
            Charactercash.TakeCash(PerkCost);
            weaponStats.damageAmount = 25;
            weaponStats.fireRate = 8;
            weaponStats.ammoMax = 50;
            weaponStats.currentAmmo = weaponStats.ammoMax;
            buffskin.SetActive(true);
            normalskin.SetActive(false);
            Pickup();
        }

        if (PerkCost > Charactercash.Cash)
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
