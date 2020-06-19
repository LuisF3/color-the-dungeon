using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponController : MonoBehaviour
{
    WeaponsManager wmanager;
    Painter painter;
    public GameObject bullet;
    public Transform weaponFront;
    [SerializeField] int damage = 1;
    [SerializeField] float bulletVelocity = 1f;
    [SerializeField] int magazineCapacity = 10;

    private void Start()
    {
        painter = GetComponent<Painter>();
        wmanager = transform.parent.GetComponent<WeaponsManager>();
    }

    public void Shoot(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            GameObject bGameObject = Instantiate(bullet, weaponFront.position, wmanager.currentWeapon.transform.rotation);
            BulletController bcontroller = bGameObject.GetComponent<BulletController>();
            Painter bPainter = bGameObject.GetComponent<Painter>();

            bcontroller.velocity = bulletVelocity;
            bcontroller.damage = damage;
            bPainter.currentColor = painter.currentColor;
        }
    }
}
