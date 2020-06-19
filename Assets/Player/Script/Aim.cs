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
    Vector2 mouseDirectionReativeToPlayer = Vector2.zero;

    private void Start()
    {
        wmanager = GetComponent<WeaponsManager>();
        currentWeaponSpriteRenderer = wmanager.currentWeapon.GetComponent<SpriteRenderer>();
        playerOrderInLayer = transform.parent.GetComponent<SpriteRenderer>().sortingOrder;
    }

    private void Update()
    {
        angle = Mathf.Atan2(mouseDirectionReativeToPlayer.y, mouseDirectionReativeToPlayer.x) * Mathf.Rad2Deg;
    }

    private void FixedUpdate()
    {
        wmanager.currentWeapon.transform.localPosition = GetLocation();
        wmanager.currentWeapon.transform.rotation = GetRotation();
    }

    public Vector2 GetLocation ()
    {
        return new Vector2(wmanager.distanceFromPlayer, wmanager.currentWeapon.transform.localPosition.y); ;
    }

    public Quaternion GetRotation()
    {
        return Quaternion.AngleAxis(angle, Vector3.forward); ;
    }

    public void AimAt(InputAction.CallbackContext context)
    {
        mouseDirectionReativeToPlayer = Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>()) - wmanager.currentWeapon.transform.position;

        // Translates the weapon to the side the player is facing
        if (wmanager.distanceFromPlayer > 0 && mouseDirectionReativeToPlayer.x < 0)
        {
            wmanager.distanceFromPlayer = -wmanager.distanceFromPlayer;
            transform.localScale = new Vector3(transform.localScale.x, -transform.localScale.y, transform.localScale.z);
        }
        else if (wmanager.distanceFromPlayer < 0 && mouseDirectionReativeToPlayer.x > 0)
        {
            wmanager.distanceFromPlayer = -wmanager.distanceFromPlayer;
            transform.localScale = new Vector3(transform.localScale.x, -transform.localScale.y, transform.localScale.z);
        }

        // Renders the weapon behind the player when he is looking up and in front of the player when he is looking down
        if (mouseDirectionReativeToPlayer.y < 0)
            currentWeaponSpriteRenderer.sortingOrder = playerOrderInLayer + 1;
        else if (mouseDirectionReativeToPlayer.y > 0)
            currentWeaponSpriteRenderer.sortingOrder = playerOrderInLayer - 1;
  
    }
}
