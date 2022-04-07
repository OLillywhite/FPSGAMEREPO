using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCash : MonoBehaviour
{
    public float Cash = 0;
    public GameObject CashUI;
    public GameObject player;
    public void AddCash(float amount)
    {
        Cash += amount;
    }

    public void TakeCash(float amount)
    {
        Cash -= amount;
    }
}
