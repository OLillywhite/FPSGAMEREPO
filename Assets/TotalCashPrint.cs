using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalCashPrint : MonoBehaviour
{
    public GameObject CashUI;
    public float CashFloat;
    public void Update()
    {
        CashFloat = GameObject.FindWithTag("Player").GetComponent<CharacterCash>().TotalCash;
        CashUI.GetComponent<Text>().text = CashFloat + "$";
    }
}
