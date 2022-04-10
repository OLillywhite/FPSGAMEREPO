using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillPrint : MonoBehaviour
{
    public GameObject KillUI;
    public int KillInt;
    public void Update()
    {
        KillInt = GameObject.FindWithTag("Player").GetComponent<KillCounter>().Killcount;
        KillUI.GetComponent<Text>().text = KillInt + "";
    }
}