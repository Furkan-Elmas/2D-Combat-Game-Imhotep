using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class BlowAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public GameObject blow;


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Player")
        {
            GameObject effect = Instantiate(blow, transform.position, Quaternion.identity);
            Destroy(effect, 3f);
            Destroy(gameObject);
        }
        if (collision.tag == "enemy")
        {
            if (collision.GetComponent<EnemyAI>().enemyCurrentHealth > 0)
            {
                collision.GetComponent<EnemyAI>().HitDamage(20);
                CameraShaker.Instance.ShakeOnce(3f, 10f, 0.1f, 0.1f);

            }
        }
    }
}
