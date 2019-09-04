using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    [SerializeField]
    private float m_TimeToDestroy;
    private void Start()
    {
        Destroy(gameObject, m_TimeToDestroy);
    }
}
