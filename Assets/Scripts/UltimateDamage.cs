using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltimateDamage : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "enemy")
        {
            if (collision.GetComponent<EnemyAI>().enemyCurrentHealth > 0)
            {
                collision.GetComponent<EnemyAI>().HitDamage(100);
            }
        }
    }
}
