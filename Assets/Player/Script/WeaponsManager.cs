using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsManager : MonoBehaviour
{
    public GameObject weaponsParent;
    List<GameObject> weapons = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in weaponsParent.transform)
        {
            weapons.Add(child.gameObject);
            child.gameObject.SetActive(false);
        }

        if (weapons.Count > 0)
            weapons[0].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
