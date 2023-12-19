using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class camscript : MonoBehaviour
{
    public Transform target; // The target to follow
    public float smoothSpeed = 0.125f; // Smoothing factor (0.125 is a good starting point)
    public Vector3 offset; // The camera's offset from the target
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
