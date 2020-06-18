using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ColorManager : MonoBehaviour
{
    Painter painter;
    PlayerInteractor pInteractor;
    // Start is called before the first frame update
    void Start()
    {
        painter = GetComponent<Painter>();
        pInteractor = GetComponent<PlayerInteractor>();
    }

    public void ColorSelf(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            List<GameObject> entities = pInteractor.interact();
            foreach (GameObject entity in entities)
            {
                Painter entityPainter = entity.GetComponent<Painter>();
                if (entity.layer == LayerMask.NameToLayer("Fountain") && entityPainter)
                    painter.applyColor(entityPainter.currentColor);
            }
        }
    }
}
