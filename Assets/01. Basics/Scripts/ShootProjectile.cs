using UnityEngine;

public class ShootProjectile : MonoBehaviour
{
    [SerializeField]
    private float m_StartSpeed = 50f;

    [SerializeField]
    private GameObject m_ProjectilePrefab = null;

    private Transform m_Transform;

    private void Start()
    {
        m_Transform = GetComponent<Transform>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SpawnProjectile();
        }
    }

    private void SpawnProjectile()
    {
        if(m_ProjectilePrefab == null)
            return;

        GameObject newProjectile = Instantiate<GameObject>(m_ProjectilePrefab, m_Transform.position, m_Transform.rotation);
        Rigidbody projectileRigidbody = newProjectile.GetComponent<Rigidbody>();
        if(projectileRigidbody != null)
        {
            Vector3 projectileVelocity = m_Transform.forward * m_StartSpeed;
            projectileRigidbody.velocity = projectileVelocity;
        }
    }
}
