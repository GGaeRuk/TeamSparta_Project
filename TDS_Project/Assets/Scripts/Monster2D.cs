using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster2D : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    public float speed = 10.0f;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.constraints = RigidbodyConstraints2D.FreezePositionY;
    }

    private void Update()
    {
        Move_2D();
    }

    private void Move_2D()
    {
        Vector3 pos = rigidbody.transform.position;
        pos = new Vector3(
            pos.x + (-1 * speed * Time.deltaTime),
            pos.y,
            pos.z
            );
        rigidbody.MovePosition(pos);
    }

}
