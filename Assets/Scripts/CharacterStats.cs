using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    [SerializeField] protected int currentHealth;
    [SerializeField] protected int maxHealth;

    [SerializeField] protected bool isDead;

    void Start()
    {
        InitVariables();
    }

    public virtual void CheckHealth()
    {
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }

        if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public void Die()
    {
        isDead = true;
    }

    private void SetHealth(int health)
    {
        currentHealth = health;
        CheckHealth();
    }

    public void GetDamage(int damage)
    {
        SetHealth(currentHealth - damage);
    }

    public void GetHeal(int heal)
    {
        SetHealth(currentHealth + heal);
    }

    public void InitVariables()
    {
        maxHealth = 100;
        SetHealth(maxHealth);
        isDead = false;
    }
}
