using UnityEngine;

public class CameraFly : MonoBehaviour
{
    [Header("Move Speed")]
    [SerializeField]
    private float m_MoveSpeed = 5f;

    [SerializeField]
    private float m_SpeedMultiplier = 3f;

    [Header("Rotation Speed")]
    [SerializeField]
    private float m_RotationSpeed = 5f;

    private Transform m_Transform;

    private Vector2 m_LastMousePosition;

    private Vector2 m_CurrentRotation;

    private void Start()
    {
        m_Transform = GetComponent<Transform>();
        m_CurrentRotation.x = m_Transform.rotation.eulerAngles.x;
        m_CurrentRotation.y = m_Transform.rotation.eulerAngles.y;
    }

    private void LateUpdate()
    {
        if(Input.GetMouseButtonDown(1))
            m_LastMousePosition = Input.mousePosition;

        if(Input.GetMouseButton(1))
        {
            Vector2 delta = ((Vector2)Input.mousePosition - m_LastMousePosition) * Time.deltaTime * m_RotationSpeed;
            m_CurrentRotation.x = Mathf.Clamp(m_CurrentRotation.x - delta.y, -180f, 180f);
            m_CurrentRotation.y = (m_CurrentRotation.y + delta.x) % 360f;

            Quaternion newRotation = Quaternion.Euler(Vector3.right * m_CurrentRotation.x + Vector3.up *m_CurrentRotation.y);
            m_Transform.rotation = newRotation;

            m_LastMousePosition = Input.mousePosition;

            Vector3 moveDireciton = m_Transform.up * GetAxis(KeyCode.E, KeyCode.Q) 
                + m_Transform.forward * GetAxis(KeyCode.W, KeyCode.S)
                + m_Transform.right * GetAxis(KeyCode.D, KeyCode.A);
            
            Vector3 moveVector = moveDireciton * m_MoveSpeed * Time.deltaTime;
            if(Input.GetKey(KeyCode.LeftShift))
                moveVector *= m_SpeedMultiplier;

            m_Transform.position += moveVector;
        }
    }

    private float GetAxis(KeyCode positive, KeyCode negative)
    {
        float axis = 0f;
        if(Input.GetKey(positive))
            axis += 1f;
        if(Input.GetKey(negative))
            axis -= 1f;

        return axis;
    }
}
