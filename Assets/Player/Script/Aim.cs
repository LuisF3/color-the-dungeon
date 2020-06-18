using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Aim : MonoBehaviour
{
    WeaponsManager wmanager;
    SpriteRenderer currentWeaponSpriteRenderer;
    int playerOrderInLayer = 0;
    float angle = 0;
    Vector2 mouseDirection = Vector2.zero;

    private void Start()
    {
        wmanager = GetComponent<WeaponsManager>();
        currentWeaponSpriteRenderer = wmanager.currentWeapon.GetComponent<SpriteRenderer>();
        playerOrderInLayer = transform.parent.GetComponent<SpriteRenderer>().sortingOrder;
    }

    private void Update()
    {
        angle = Mathf.Atan2(mouseDirection.y, mouseDirection.x) * Mathf.Rad2Deg;
    }

    private void FixedUpdate()
    {
        wmanager.currentWeapon.transform.localPosition = new Vector2(wmanager.distanceFromPlayer, wmanager.currentWeapon.transform.localPosition.y);
        wmanager.currentWeapon.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    public void AimAt(InputAction.CallbackContext context)
    {
        mouseDirection = context.ReadValue<Vector2>();

        // Translates the weapon to the side the player is facing
        if (wmanager.distanceFromPlayer > 0 && mouseDirection.x - Camera.main.pixelWidth / 2 < 0)
        {
            wmanager.distanceFromPlayer = -wmanager.distanceFromPlayer;
            transform.localScale = new Vector3(transform.localScale.x, -transform.localScale.y, transform.localScale.z);
        }
        else if (wmanager.distanceFromPlayer < 0 && mouseDirection.x - Camera.main.pixelWidth / 2 > 0)
        {
            wmanager.distanceFromPlayer = -wmanager.distanceFromPlayer;
            transform.localScale = new Vector3(transform.localScale.x, -transform.localScale.y, transform.localScale.z);
        }

        // Renders the weapon behind the player when he is looking up and in front of the player when he is looking down
        if (mouseDirection.y < 0)
            currentWeaponSpriteRenderer.sortingOrder = playerOrderInLayer + 1;
        else if (mouseDirection.y > 0)
            currentWeaponSpriteRenderer.sortingOrder = playerOrderInLayer - 1;

        mouseDirection = Camera.main.ScreenToWorldPoint(mouseDirection) - transform.position;        
    }
}
