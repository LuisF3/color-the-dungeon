using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ColorManager : MonoBehaviour
{
    public SpriteRenderer colored_part;
    public Color currentColor = Color.black;
    PlayerInteractor pInteractor;
    // Start is called before the first frame update
    void Start()
    {
        pInteractor = GetComponent<PlayerInteractor>();
        if (currentColor == Color.black)
            colored_part.color = new Color(0.83f, 0.83f, 0.83f, 1f);
        else
            colored_part.color = currentColor;
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

        if (currentColor == Color.black)
            colored_part.color = new Color(0.83f, 0.83f, 0.83f, 1f);
        else
        {
            currentColor = new Color(Mathf.Min(currentColor.r, 1f), Mathf.Min(currentColor.g, 1f), Mathf.Min(currentColor.b, 1f), Mathf.Min(currentColor.a, 1f));
            colored_part.color = currentColor;
        }
    }
}
