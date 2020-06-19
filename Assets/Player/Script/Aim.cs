using UnityEngine;
using UnityEngine.InputSystem;

public class Aim : MonoBehaviour
{
    WeaponsManager wmanager;
    float angle = 0;
    Vector3 mousePosition = Vector3.zero;

    private void Start()
    {
        wmanager = GetComponent<WeaponsManager>();
    }

    private void Update()
    {
        angle = Vector2.SignedAngle(transform.right, mousePosition - transform.position);
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
