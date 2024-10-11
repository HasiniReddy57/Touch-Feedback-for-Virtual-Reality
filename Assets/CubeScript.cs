using UnityEngine;

public class CubeScript : MonoBehaviour
{
    private Color originalColor;
    private Renderer cubeRenderer;

    void Start()
    {
        cubeRenderer = GetComponent<MeshRenderer>();
        originalColor = cubeRenderer.material.color;
    }

    public void SetColor(Color color)
    {
        cubeRenderer.material.color = color;
    }

    public void ResetColor()
    {
        cubeRenderer.material.color = originalColor;
    }
}
