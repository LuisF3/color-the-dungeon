using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FollowMouse : MonoBehaviour
{
    
    public float distanceFromOrigin = 0.5f;
    public float angle = 0;
    Vector2 mouseDirection = Vector2.zero;

    private void Update()
    {
        angle = Mathf.Atan2(mouseDirection.y, mouseDirection.x) * Mathf.Rad2Deg;
    }

    private void FixedUpdate()
    {
        transform.localPosition = new Vector2(distanceFromOrigin, 0);
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    public void Aim(InputAction.CallbackContext context)
    {
        mouseDirection = context.ReadValue<Vector2>();

        if (distanceFromOrigin > 0 && mouseDirection.x - Camera.main.pixelWidth / 2 < 0)
            distanceFromOrigin = -distanceFromOrigin;
        else if (distanceFromOrigin < 0 && mouseDirection.x - Camera.main.pixelWidth / 2 > 0)
            distanceFromOrigin = -distanceFromOrigin;

        mouseDirection = Camera.main.ScreenToWorldPoint(mouseDirection) - transform.position;        
    }
}
