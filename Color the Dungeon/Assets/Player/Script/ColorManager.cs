using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ColorManager : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Color currentColor = Color.black;
    PlayerInteractor pInteractor;
    // Start is called before the first frame update
    void Start()
    {
        pInteractor = GetComponent<PlayerInteractor>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = currentColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ColorSelf(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            LayerMask excludePlayer = LayerMask.GetMask("Player") ^ 2147483647;

            Collider2D[] collisions = Physics2D.OverlapCircleAll(pInteractor.interactionPoint.position, pInteractor.interactionRange, excludePlayer);
            foreach (Collider2D entity in collisions)
            {
                Painter entityPainter = entity.GetComponent<Painter>();
                if (entity.gameObject.layer == LayerMask.NameToLayer("Fountain") && entityPainter)
                {
                    if (entityPainter.color == Color.black)
                        currentColor = Color.black;
                    else 
                        currentColor += entityPainter.color;
                }
            }
        }

        spriteRenderer.color = currentColor;
    }
}
