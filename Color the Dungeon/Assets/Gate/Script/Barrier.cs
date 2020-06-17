using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    Transform player_transform;
    ColorManager player_colorManager;
    Collider2D collider_2D;
    public SpriteRenderer colored_part;
    public Color color = Color.black;
    public bool open = false;
    [SerializeField] float openRange = 5f;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player_transform = player.transform;
        player_colorManager = player.GetComponent<ColorManager>();

        collider_2D = GetComponent<Collider2D>();
        colored_part.color = color;
    }

    // Update is called once per frame
    void Update()
    {
        if ((player_transform.position - transform.position).sqrMagnitude < openRange * openRange && player_colorManager.currentColor == color)
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
