using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class VisualiseConnection : MonoBehaviour
{
    public Transform start, end;

    public float width = 0.2f;

    public Material material;

    private LineRenderer lineRenderer;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        lineRenderer.widthMultiplier = width;
        lineRenderer.material = material;
    }

    private void LateUpdate()
    {
        lineRenderer.SetPosition(0, start.position);
        lineRenderer.SetPosition(1, end.position);
    }
}
