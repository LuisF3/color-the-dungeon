using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Rigidbody2D rb;
    public Vector2 from;
    public Vector2 to;
    Vector2 direction;
    public float velocity = 5f;
    bool goingToFrom = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direction = (to - rb.position).normalized;
    }

    private void Update()
    {
        if (!goingToFrom && (to - rb.position).sqrMagnitude <= 0.1 || goingToFrom && (from - rb.position).sqrMagnitude <= 0.1)
        {
            goingToFrom = !goingToFrom;
            direction = (goingToFrom ? from - rb.position : to - rb.position).normalized;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (goingToFrom)
        {
            rb.MovePosition(rb.position + direction * velocity * Time.fixedDeltaTime);
        }
        else
        {
            rb.MovePosition(rb.position + direction * velocity * Time.fixedDeltaTime);
        }
    }
}
