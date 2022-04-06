using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int enemyHP = 100;
    public GameObject projectile;
    public Transform projectilePoint;
    public AudioSource Zombiesound;
    public Animator animator;
    public AudioSource Bruh;
    public CharacterCash characterCash;
    public GameObject Player;
    public void shoot()
    {
        Rigidbody rb = Instantiate(projectile, projectilePoint.position, Quaternion.identity).GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * 30f, ForceMode.Impulse);
        rb.AddForce(transform.up * 7, ForceMode.Impulse);
    }

    public void TakeDamage(int damageAmount)
    {
      enemyHP -= damageAmount;
        if(enemyHP <= 0)
        {
            animator.SetTrigger("Death");
            //new WaitForSeconds(3);
            GetComponent<CapsuleCollider>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = true;
            Player.GetComponent<CharacterCash>().AddCash(500f);
            Bruh.Play();
        }
        //else
        //{
        //    animator.SetTrigger("Damage");
        //}
    }
    public void sound()
    {
        Zombiesound.Play();
    }
}
