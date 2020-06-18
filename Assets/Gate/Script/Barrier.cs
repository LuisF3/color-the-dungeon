using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    Transform player_transform;
    Painter painter;
    Painter player_painter;
    Collider2D collider_2D;
    public bool open = false;
    [SerializeField] float openRange = 5f;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player_transform = player.transform;
        player_painter = player.GetComponent<Painter>();

        painter = GetComponent<Painter>();
        collider_2D = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((player_transform.position - transform.position).sqrMagnitude < openRange * openRange && player_painter.currentColor == painter.currentColor)
            open = true;
        else 
            open = false;
    }

    private void FixedUpdate()
    {
        collider_2D.isTrigger = open;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, openRange);
    }
}
