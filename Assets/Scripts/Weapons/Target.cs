using UnityEngine;

public class Target : MonoBehaviour
{
    public Animator animator;
    public float health = 50f;


    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
       
    }

    void Die()
    {
        animator.SetTrigger("Death");

        new WaitForSeconds(2);

        Destroy(gameObject);
    }

}