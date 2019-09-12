using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SetAngularVelocity : MonoBehaviour
{
    public Vector3 m_AngularVelocity = Vector3.zero;

    public bool onKeyDown = false;

    public KeyCode key = KeyCode.Space;

    private void Start()
    {
        if(!onKeyDown)
            SetVelocity();
    }

    private void Update()
    {
        if(onKeyDown && Input.GetKeyDown(key))
            SetVelocity();
    }

    private void SetVelocity()
    {
        Rigidbody myRigidbody = GetComponent<Rigidbody>();
        myRigidbody.AddRelativeTorque(m_AngularVelocity, ForceMode.VelocityChange);
    }
}
