using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorHitEnemy : MonoBehaviour
{
    EnemyAI meteorEnemy;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "enemy")
        {
            meteorEnemy = collision.GetComponent<EnemyAI>();
            meteorEnemy.HitDamage(50f);
            print("vurdu..");
        }
    }
}
