using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustGravity : MonoBehaviour
{
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
            Physics.gravity = Vector3.down * 0f;
        else if(Input.GetKeyDown(KeyCode.Alpha2))
            Physics.gravity = Vector3.down * 2f;
        else if(Input.GetKeyDown(KeyCode.Alpha3))
            Physics.gravity = Vector3.down * 3f;
        else if(Input.GetKeyDown(KeyCode.Alpha4))
            Physics.gravity = Vector3.down * 4f;
        else if(Input.GetKeyDown(KeyCode.Alpha5))
            Physics.gravity = Vector3.down * 5f;
        else if(Input.GetKeyDown(KeyCode.Alpha6))
            Physics.gravity = Vector3.down * 6f;
        else if(Input.GetKeyDown(KeyCode.Alpha7))
            Physics.gravity = Vector3.down * 7f;
        else if(Input.GetKeyDown(KeyCode.Alpha8))
            Physics.gravity = Vector3.down * 8f;
        else if(Input.GetKeyDown(KeyCode.Alpha9))
            Physics.gravity = Vector3.down * 9f;
        else if(Input.GetKeyDown(KeyCode.Alpha0))
            Physics.gravity = Vector3.down * 10f;
    }
}
