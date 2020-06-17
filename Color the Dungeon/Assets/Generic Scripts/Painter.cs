using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Painter : MonoBehaviour
{
    public SpriteRenderer colored_part;
    public Color defaultColor;
    public Color color = Color.black;

    private void Start()
    {
        if (color == Color.black)
            colored_part.color = defaultColor;
        else
            colored_part.color = color;
    }
}
