using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponController : MonoBehaviour
{
    Aim aim;
    Painter painter;
    public GameObject bullet;
    public Transform bulletSpawnLocation;
    [SerializeField] int damage = 1;
    [SerializeField] float bulletVelocity = 1f;
    [SerializeField] int magazineCapacity = 10;

    private void Start()
    {
        painter = GetComponent<Painter>();
        aim = transform.parent.GetComponent<Aim>();
    }

    public void Shoot(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Vector2 locationRelativeToPlayer = aim.GetLocation();
            BulletController bController = Instantiate(bullet, bulletSpawnLocation.position, aim.GetRotation()).GetComponent<BulletController>();

            bController.velocity = bulletVelocity;
        }
    }
}
