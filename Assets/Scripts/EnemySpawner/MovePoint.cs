using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePoint : MonoBehaviour
{
    public GameObject movepoint;
    public GameObject point1;
    public GameObject point2;
    public GameObject point3;
    public GameObject point4;
    public GameObject point5;
    public GameObject point6;
    public int pointTracker;   

    void Update()
    {

        StartCoroutine(IncrimentPoint());

        if (pointTracker == 0)
        {
            movepoint.transform.position = point1.transform.position;
        }

        if (pointTracker == 1)
        {
            movepoint.transform.position = point2.transform.position;
        }

        if (pointTracker == 2)
        {
            movepoint.transform.position = point3.transform.position;
        }

        if (pointTracker == 3)
        {
            movepoint.transform.position = point4.transform.position;
        }

        if (pointTracker == 4)
        {
            movepoint.transform.position = point5.transform.position;
        }

        if (pointTracker == 5)
        {
            movepoint.transform.position = point6.transform.position;
        }

    }

    IEnumerator IncrimentPoint()
    {
        yield return new WaitForSeconds(1);
        pointTracker += 1;
        if (pointTracker == 6)
        {
            pointTracker = 0;
        }

    }
}
