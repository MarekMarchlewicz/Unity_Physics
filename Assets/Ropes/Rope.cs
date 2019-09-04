using UnityEngine;

public class Rope : MonoBehaviour
{
    public Rigidbody startPoint;

    public Rigidbody attachment;

    [Range(2, 20)]
    public int segments;

    public void Generate()
    {

    }
}
