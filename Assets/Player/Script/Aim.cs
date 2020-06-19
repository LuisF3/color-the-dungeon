using UnityEngine;
using UnityEngine.InputSystem;

public class Aim : MonoBehaviour
{
    WeaponsManager wmanager;
    WeaponController currentWeapon;
    float angle = 0;
    Vector3 mousePosition = Vector3.zero;
    bool facingRight = true;

    private void Start()
    {
        wmanager = GetComponent<WeaponsManager>();
        currentWeapon = wmanager.currentWeapon.GetComponent<WeaponController>();
    }

    private void Update()
    {
        if (mousePosition.x - transform.position.x > 0 && !facingRight || mousePosition.x - transform.position.x < 0 && facingRight)
        {
            currentWeapon.transform.localPosition = new Vector3(-currentWeapon.transform.localPosition.x, currentWeapon.transform.localPosition.y, currentWeapon.transform.localPosition.z);
            currentWeapon.transform.localScale = new Vector3(1, facingRight ? -1 : 1, 1);
            facingRight = !facingRight;
        }

        angle = Vector2.SignedAngle(Vector2.right, mousePosition - currentWeapon.weaponFront.transform.position);
    }

    private void FixedUpdate()
    {
        wmanager.currentWeapon.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    public void AimAt(InputAction.CallbackContext context)
    {
        mousePosition = Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>());
    }
}
