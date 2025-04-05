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

    public float climbHeight = 1.2f;
    private bool isOnTop = false;
    private bool isClimbing = false;
    private Vector2 climbStartPos;
    private Vector2 climbEndPos;
    public float climbSpeed = 2.0f;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (!isOnTop)
        {
            Move_2D();
        }

        if (isClimbing)
        {
            ClimbOnTop();
        }
    }

    private void Move_2D()
    {
        rigidbody.velocity = new Vector2(-speed, rigidbody.velocity.y);
    }

    private IEnumerator IEAttack()
    {
        isAttack = true;
        while (isAttack)
        {
            animator.SetBool("IsAttacking", true);

            yield return null;
        }
        animator.SetBool("IsAttacking", false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Hero") && !isAttack)
        {
            StartCoroutine(IEAttack());
        }

        if (collision.gameObject.CompareTag("Monster") && !isOnTop)
        {
            Monster2D otherMonster = collision.gameObject.GetComponent<Monster2D>();

            if (otherMonster != null && transform.position.x > collision.transform.position.x)
            {
                climbStartPos = transform.position;
                climbEndPos = new Vector2(transform.position.x, collision.transform.position.y + climbHeight);
                isClimbing = true;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Hero") && isAttack)
        {
            isAttack = false;
            StopCoroutine(IEAttack());
            animator.SetBool("IsAttacking", false);
            Debug.Log("Attack End");
        }
    }

    private void ClimbOnTop()
    {
        transform.position = Vector2.MoveTowards(transform.position, climbEndPos, climbSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, climbEndPos) < 0.1f)
        {
            isClimbing = false;
            isOnTop = true;
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