using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class camscript : MonoBehaviour
{
    public Transform target; 
    public float smoothSpeed = 0.125f; 
    public Vector3 offset; 
    public float camrange = 5;
    void FixedUpdate()
    {
        if (target == null)
            return;
        Vector2 mousepos = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition) - new Vector2(0.5f, 0.5f);
        
        Vector3 desiredPosition = target.position + offset + new Vector3(mousepos.x, 0, mousepos.y) * camrange;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
