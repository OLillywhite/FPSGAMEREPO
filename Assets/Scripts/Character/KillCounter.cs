using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillCounter : MonoBehaviour
{
    public int Killcount;

    public void AddKill (int amount)
    {
        Killcount += amount;
    }
}
