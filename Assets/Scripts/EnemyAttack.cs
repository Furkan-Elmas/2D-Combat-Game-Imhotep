using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float enemyMaxHealth = 100f;
    [SerializeField] private float enemyCurrentHealth;
    [SerializeField] private Animator animator;

    void Start()
    {
        enemyCurrentHealth = enemyMaxHealth;
    }

    public void TakeDamage(float damage)
    {
        enemyCurrentHealth -= damage;
        

        if (enemyCurrentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {

    }
}
