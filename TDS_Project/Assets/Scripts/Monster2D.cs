using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster2D : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    public float speed = 5.0f;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.constraints = RigidbodyConstraints2D.FreezePositionY;
    }

    private void FixedUpdate()
    {
        Move_2D();
    }

    private void Move_2D()
    {
        Vector2 pos = rigidbody.transform.position;
        pos = new Vector2(
            pos.x + (-1 * speed * Time.deltaTime),
            pos.y
            );
        rigidbody.MovePosition(pos);
    }

}
