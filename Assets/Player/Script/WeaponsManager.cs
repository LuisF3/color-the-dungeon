using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsManager : MonoBehaviour
{
    [HideInInspector] public GameObject currentWeapon = null;
    public float distanceFromPlayer = 0.4f;
    public Aim aim;
    List<GameObject> weapons = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in transform)
        {
            weapons.Add(child.gameObject);
            child.gameObject.SetActive(false);
        }

        if (weapons.Count > 0)
            selectWeapon(0);

    }

    void selectWeapon(int i)
    {
        currentWeapon = weapons[i];
        currentWeapon.SetActive(true);
        aim.enabled = true;
    }
}
