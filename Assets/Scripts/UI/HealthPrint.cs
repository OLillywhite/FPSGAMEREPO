using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPrint : MonoBehaviour
{
    public GameObject HealthUI;
    public float HealthFloat;
    public void Update()
    {
        HealthFloat = GameObject.FindWithTag("Player").GetComponent<CharacterHealth>().health;
        HealthUI.GetComponent<Text>().text = "" + HealthFloat;
    }
}

