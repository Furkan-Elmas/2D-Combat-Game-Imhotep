using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.Universal;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float enemyMaxHealth = 100f;
    [SerializeField] public float enemyCurrentHealth;
    [SerializeField] public float enemyAttackDamage = 5f;

    [SerializeField] private float speed;
    [SerializeField] private float checkRadius;
    [SerializeField] private float attackRadius;

    [SerializeField] private Rigidbody2D playerRB;
    [SerializeField] private RuntimeAnimatorController goodMan;
    [SerializeField] private GameObject goodManLight;

    [SerializeField] private bool shouldRotate;

    [SerializeField] private LayerMask playerLayer;

    [SerializeField] private Transform attackPoint;
    [SerializeField] private Vector3 direction;

    public CharacterHealth characterHealth;
    public GameObject BossHealtBar;
    public Text BossHealtBarReduced;

    private Transform _target;
    private Rigidbody2D _rigidbodyEnemy;
    private Animator _animator;
    private Vector2 _movement;
    public ManagerSC ManagerSC;
    public GameObject GlobalLight;
    public float playerAttackRadius = 0.2f;

    public Slider healtBar;

    private float _coolDown = 1f;

    private bool _isInChaseRange;
    private bool _isInAttackRange;

    private void Start()
    {
        enemyCurrentHealth = enemyMaxHealth;

        _animator = GetComponent<Animator>();
        _rigidbodyEnemy = GetComponent<Rigidbody2D>();
        _target = GameObject.FindWithTag("Player").transform;


    }
    private void Update()
    {
        _isInChaseRange = Physics2D.OverlapCircle(transform.position, checkRadius, playerLayer);
        _isInAttackRange = Physics2D.OverlapCircle(transform.position + new Vector3(0, 0.32f, 0), attackRadius, playerLayer);

        direction = _target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        direction.Normalize();
        _movement = direction;
        if (direction.x > 0)
        {
            transform.GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (direction.x < 0)
        {
            transform.GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    private void FixedUpdate()
    {
        _coolDown += Time.deltaTime;

        if (enemyCurrentHealth > 0)
        {
            if (_isInChaseRange && !_isInAttackRange)
            {
                MoveCharacter(_movement);
                _animator.SetInteger("AnimState", 2);
                if (healtBar.name == "BossHealtBar")
                {
                    BossHealtBar.SetActive(true);
                }
            }

            else if (_isInAttackRange && _coolDown >= 1f)
            {
                Attack();
                _rigidbodyEnemy.velocity = Vector2.zero;
                _animator.SetInteger("AnimState", 0);
                _coolDown = 0f;
            }
            else if (_isInAttackRange)
            {
                _rigidbodyEnemy.velocity = Vector2.zero;
                _animator.SetInteger("AnimState", 0);
            }
            else
            {
                _rigidbodyEnemy.velocity = Vector2.zero;
                _animator.SetTrigger("Death");
                if (healtBar.name == "BossHealtBar")
                {
                    BossHealtBar.SetActive(false);
                }
            }
        }

        if (enemyCurrentHealth <= 0 && enemyCurrentHealth >= -100)
        {
            _rigidbodyEnemy.velocity = Vector2.zero;
            StartCoroutine(KillEnemy());

        }
        if (enemyCurrentHealth == -101)
        {
            BeAlly();
        }

    }

    private void MoveCharacter(Vector2 direction)
    {
        _rigidbodyEnemy.MovePosition((Vector2)transform.position + (direction * speed * Time.fixedDeltaTime));
    }

    private void Attack()
    {
        _animator.SetTrigger("Attack");

        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius + playerAttackRadius, playerLayer);

        foreach (Collider2D hit in hitPlayer)
        {
            if (hit.tag == "Player")
            {
                characterHealth = hit.GetComponentInParent<CharacterHealth>();
                if (characterHealth.playerCurrentHealth > 0)
                {
                    hit.GetComponentInParent<Animator>().SetTrigger("Hurt");
                    hit.GetComponentInParent<CharacterHealth>().TakeDamage(enemyAttackDamage);
                }
            }
        }
    }

    public void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    }

    public void HitDamage(float damage)
    {
        _animator.SetTrigger("Hurt");

        enemyCurrentHealth -= damage;
        healtBar.value -= damage;


        if (healtBar.name == "BossHealtBar")
        {
            enemyCurrentHealth = enemyMaxHealth - (characterHealth._killedEnemyCount * 400);
            healtBar.value = enemyCurrentHealth;

            if (healtBar.value == 0)
            {
                ManagerSC.bossDeathPanel();
            }
        }
    }

    IEnumerator KillEnemy()
    {
        enemyCurrentHealth = -101;
        characterHealth._killedEnemyCount++;
        BossHealtBarReduced.text = "Boss Can Deðeri " + characterHealth._killedEnemyCount * 400 + " Azaldý...";
        GlobalLight.GetComponent<Light2D>().intensity += 0.05f;

        if (characterHealth._killedEnemyCount >= 10)
        {
            characterHealth.TurnOffTheLight();
        }
        BossHealtBarReduced.enabled = true;
        _animator.SetTrigger("Death");
        yield return new WaitForSeconds(3f);
        _animator.SetTrigger("Recover");
        BossHealtBarReduced.enabled = false;
        yield return new WaitForSeconds(1f);

        _rigidbodyEnemy.GetComponent<Animator>().runtimeAnimatorController = goodMan;
        goodManLight.SetActive(true);
        attackRadius = .7f;
    }

    public void BeAlly()
    {
        //_rigidbodyEnemy.transform.position = Vector2.Lerp(_rigidbodyEnemy.transform.position, playerRB.transform.position + new Vector3(.5f,.5f,0), Time.deltaTime);
        _animator.SetInteger("AnimState", 0);
        healtBar.GetComponentInParent<Canvas>().enabled = false;

    }
}
