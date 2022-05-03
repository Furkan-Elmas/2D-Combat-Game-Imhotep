using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    Rigidbody2D rb;

    Animator animator;

    public float speed = 12f;

    bool m_IsMoving;

    float animRateNormalAttack = 1f;
    float animRateUltiAttack = 60f;
    public Bullet fireAnimCancel;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        fireAnimCancel = GetComponent<Bullet>();
    }

    private void LateUpdate()
    {
        fireAnimCancel.playerCurrentMana += 5f * Time.deltaTime;
        fireAnimCancel.playerManaSlider.value = fireAnimCancel.playerCurrentMana;

        animRateNormalAttack += Time.deltaTime;
        animRateUltiAttack += Time.deltaTime;

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector2 move = transform.right * horizontal + transform.up * vertical;

        move = move.normalized;

        rb.MovePosition(rb.position + move * speed * Time.fixedDeltaTime);

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            m_IsMoving = true;
        }
        else { m_IsMoving = false; }

        if (Input.GetKey(KeyCode.Mouse0) && animRateNormalAttack >= 1f && fireAnimCancel.playerCurrentMana >=5f)
        {
            animator.SetTrigger("attack1");
            animRateNormalAttack = 0f;

        }
        
        if (Input.GetKeyDown(KeyCode.E) && animRateUltiAttack >= 60f)
        {
            animator.SetBool("attack2", true);
            animRateUltiAttack = 0f;
        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            animator.SetBool("attack2", false);
        }
        if (horizontal < 0 && m_IsMoving)
        {
            animator.SetFloat("runSpeed", 1f);
        }
        else if (horizontal > 0 && m_IsMoving)
        {
            animator.SetFloat("runSpeed", 1f);
        }
        if (vertical < 0 || vertical > 0)
        {
            animator.SetFloat("runSpeed", 1f);
        }
        else if (!m_IsMoving)
        {
            animator.SetFloat("runSpeed", 0f);
        }

    }

}
