using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster2D : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    public float speed = 2.0f;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move_2D();
    }

    private void Move_2D()
    {
        rigidbody.velocity = new Vector2(-speed, rigidbody.velocity.y);
    }
}