using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetFixedTimestep : MonoBehaviour
{
    public float m_FixedTimestep = 0.02f;

    private void Start()
    {
        Time.fixedDeltaTime = m_FixedTimestep;
    }
}
