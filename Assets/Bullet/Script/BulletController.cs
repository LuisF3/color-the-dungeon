using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    Rigidbody2D rb;
    public float velocity = 1f;
    float angle;
    Vector2 direction;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        angle = transform.rotation.eulerAngles.z;
    }

    private void Update()
    {
        direction = (new Quaternion(0, 0, angle, 1) * transform.right * -1).normalized;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + direction * velocity* Time.fixedDeltaTime);
    }
}
