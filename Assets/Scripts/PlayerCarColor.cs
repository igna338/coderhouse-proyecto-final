using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCarColor : MonoBehaviour
{
    private Color carColor;
    public Renderer carRenderer;

    public void ChangeColor(int colorNumber)
    {
        switch (colorNumber)
        {
            case 0:
                carColor = Color.red;
                break;
            case 1:
                carColor = Color.black;
                break;
            case 2:
                carColor = Color.white;
                break;
        }

        carRenderer.materials[1].color = carColor;
    }
}
