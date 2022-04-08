using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Gunbuff2 : MonoBehaviour
{
    public GameObject PerkUI;
    public GameObject player;
    public GameObject BrokeBoiUI;
    public float PerkCost = 10000f;
    bool triggered = false;
    public AudioSource Purchased;
    public GameObject GunOBJ;
    public GameObject normalskin;
    public GameObject buffskin;
    //public GameObject gunBuff3;

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
            weaponStats.damageAmount = 35;
            weaponStats.fireRate = 10;
            weaponStats.ammoMax = 65;
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
        //gunBuff3.SetActive(true);
        Destroy(gameObject);
    }
}
