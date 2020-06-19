using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    Rigidbody2D rb;
    public Painter painter;
    public float collideRadius = 0.1f;
    public float velocity = 1f;
    public int damage = 1;
    float angle;
    Vector2 direction;
    Collider2D[] hits;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        angle = transform.rotation.eulerAngles.z;
    }

    private void Update()
    {
        direction = (new Quaternion(0, 0, angle, 1) * transform.right * -1).normalized;
        hits = Physics2D.OverlapCircleAll(transform.position, collideRadius, LayerMask.GetMask("Enemy", "Wall"));
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + direction * velocity * Time.fixedDeltaTime);
        if (hits.Length > 0)
        {
            foreach (Collider2D entity in hits)
            {
                if (LayerMask.LayerToName(entity.gameObject.layer) == "Enemy" && entity.GetComponent<Painter>().currentColor == painter.currentColor)
                    entity.GetComponent<LifeController>().Damage(damage);
                Destroy(gameObject);
            }
        }
    }
}
