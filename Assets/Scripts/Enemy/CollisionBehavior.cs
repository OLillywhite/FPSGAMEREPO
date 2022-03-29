using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionBehavior : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag.Equals("Player"))
        {
            CharacterHealth characterHealth = collision.collider.gameObject.GetComponent<CharacterHealth>();


            characterHealth.TakeDamage(15);
        }


    }
}
