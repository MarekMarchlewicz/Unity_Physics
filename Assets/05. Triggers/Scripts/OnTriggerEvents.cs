using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerEvents : MonoBehaviour
{
    public float m_DebugTime = 0.3f;

    public Color m_DebugColor = new Color(1f, 0f, 0f, 0.5f);

    private Color m_OriginalColor;

    private Material m_Material;

    public enum TriggerEventType
    {
        Enter,
        Stay,

        Exit
    }

    public TriggerEventType m_TriggerEventType;

    private void Awake()
    {
        m_Material = GetComponent<Renderer>().material;
        m_OriginalColor = m_Material.color;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(m_TriggerEventType == TriggerEventType.Enter)
        {
            ShowDebug();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(m_TriggerEventType == TriggerEventType.Stay)
        {
            ShowDebug();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(m_TriggerEventType == TriggerEventType.Exit)
        {
            ShowDebug();
        }
    }

    private void ShowDebug()
    {
        StopAllCoroutines();
        StartCoroutine(ChangeMaterial());
    }

    private IEnumerator ChangeMaterial()
    {
        m_Material.color = m_DebugColor;

        yield return new WaitForSeconds(m_DebugTime);

        m_Material.color = m_OriginalColor;

        yield return null;
    }
}
