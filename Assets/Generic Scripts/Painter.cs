using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Painter : MonoBehaviour
{
    public SpriteRenderer colored_part;
    public Color defaultColor;
    public Color currentColor = Color.black;

    private void Start()
    {
        if (currentColor == Color.black)
            colored_part.color = defaultColor;
        else
            colored_part.color = currentColor;
    }

    public void applyColor(Color color)
    {
        Debug.Log("Applying color " + color);
        if (color == Color.black)
        {
            currentColor = Color.black;
            colored_part.color = defaultColor;
        }
        else
        {
            currentColor += color;
            colored_part.color = currentColor;
        }
    }
}
