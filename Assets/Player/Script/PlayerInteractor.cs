using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    public Transform interactionPoint;
    public float interactionRange = 1f;

    public List<GameObject> interact()
    {
        List<GameObject> entities = new List<GameObject>();

        LayerMask excludePlayer = LayerMask.GetMask("Player") ^ 2147483647;
        Collider2D[] collisions = Physics2D.OverlapCircleAll(interactionPoint.position, interactionRange, excludePlayer);

        foreach (Collider2D entity in collisions)
            entities.Add(entity.gameObject);

        return entities;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(interactionPoint.position, interactionRange);
    }
}
