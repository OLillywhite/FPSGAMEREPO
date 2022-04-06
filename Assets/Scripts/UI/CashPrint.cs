using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CashPrint : MonoBehaviour
{
    public GameObject CashUI;
    public float CashFloat;
    public void Update()
    {
        CashFloat = GameObject.FindWithTag("Player").GetComponent<CharacterCash>().Cash;
        CashUI.GetComponent<Text>().text = CashFloat + "$";
    }
}