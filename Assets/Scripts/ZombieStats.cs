using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieStats : CharacterStats
{
    [SerializeField] private int damage;
    [SerializeField] public float attackSpeed;

    [SerializeField] private bool canAttack;
    [SerializeField] private GameObject deadversion;

    private void Start()
    {
        InitVariables();
    }

    public void DealDamage(CharacterStats statsToDamage)
    {
        statsToDamage.TakeDamage(damage);
    }

    public override void Die()
    {
        base.Die();
        Instantiate(deadversion, transform.position, transform.rotation * Quaternion.Euler(-90f, 0f, 0f));
        Destroy(gameObject);
    }

    public override void InitVariables()
    {
        maxHealth = 100;
        SetHealthTo(maxHealth);
        isDead = false;

        damage = 10;
        attackSpeed = 1.5f;
        canAttack = true;
    }
}
