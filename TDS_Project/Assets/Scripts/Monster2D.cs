using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster2D : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private Animator animator;
    public float speed = 2.0f;
    public float attackInterval = 1.0f;
    private bool isAttack = false;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Move_2D();
    }

    private void Move_2D()
    {
        rigidbody.velocity = new Vector2(-speed, rigidbody.velocity.y);
    }

    private IEnumerator IEAttack()
    {
        isAttack = true;
        while (true)
        {
            animator.SetBool("IsAttacking", true);

            yield return null;

            if (!isAttack)
            {
                break;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Hero") && !isAttack)
        {
            StartCoroutine(IEAttack());
        }
    }
    public void OnAttack()
    {
        Debug.Log("Attack");
    }

    public void OnAttackEnd()
    {
        animator.SetBool("IsAttacking", false);
        Debug.Log("Attack End");
    }
}