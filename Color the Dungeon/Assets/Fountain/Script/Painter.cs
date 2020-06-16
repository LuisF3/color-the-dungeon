using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Painter : MonoBehaviour
{
    [SerializeField] SpriteRenderer colored_part;
    public Color color = Color.black;

    private void Start()
    {
        if (color == Color.black)
            colored_part.color = new Color(0.54f, 0.8f, 0.94f, 1f);
        else 
            colored_part.color = color;
    }
}
