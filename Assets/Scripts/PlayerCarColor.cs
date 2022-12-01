using UnityEngine;

public class PlayerCarColor : MonoBehaviour
{
    public Renderer carRenderer;
    private GameManager gameManager;

    private void Awake()
    {
        gameManager = GameManager.inst;
    }

    public void Start()
    {
        carRenderer.materials[1].color = gameManager.carColorSelected;
    }
}
