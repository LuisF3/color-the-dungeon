using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour
{
    public int healthPoints = 3;

    public void Damage(int amount)
    {
        healthPoints -= amount;
        if (healthPoints == 0)
            Die();
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
