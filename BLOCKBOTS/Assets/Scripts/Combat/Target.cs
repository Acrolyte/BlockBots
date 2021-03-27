using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int health = 50;
    public HealthBar healthbar;
    
    public ParticleSystem deatheffect;
    
    public void TakeDamage(int amount)
    {
        health -= amount;
        ScoreManager.instance.sce.IncreaseScore(amount);
        healthbar.SetHealth(health);
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Instantiate(deatheffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
