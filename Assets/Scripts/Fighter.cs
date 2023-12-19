using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Fighter : MonoBehaviour
{
    public PlayerInput pinput;
    public InputAction move;
    private InputAction dash;
    private InputAction fire;
    public float force;
    public Rigidbody rb;
    public Transform target;

    public Weapon weapon;
    public float dashSpeed = 200f;       
    public float dashDuration = 0.2f;    
    public float dashCooldown = 1.0f;    
    private bool isDashing = false;
    private bool canDash = true;
    // Start is called before the first frame update
    void Start()
    {
        move = pinput.actions.FindAction("Move");
        dash = pinput.actions.FindAction("Dash");
        fire = pinput.actions.FindAction("Fire");

    }

    // Update is called once per frame
    void Update()
    {
        if (fire.WasPressedThisFrame()) 
        {
            //Debug.Log(10);
            weapon.Fire();
        }
        if (fire.WasReleasedThisFrame())
        {
            //Debug.Log(11);
            weapon.StopFire();
        }
        LookAtMouseCursor();
        if (dash.triggered && !isDashing && canDash)
        {
            StartCoroutine(Dash());
        }
    }
    private void FixedUpdate()
    {
        Movement();
    }
    public void Movement() 
    {
        Vector2 dir = move.ReadValue<Vector2>();
        rb.AddForce((Vector3.forward * dir.y + Vector3.right * dir.x).normalized * force);


        
    }
    public void LookAtMouseCursor()
    {

        transform.rotation = Quaternion.LookRotation(target.position - transform.position,Vector3.up);
        
    }
    private IEnumerator Dash()
    {
        isDashing = true;
        canDash = false;

        
        Vector2 dir = move.ReadValue<Vector2>();
        Vector3 dashVelocity = (Vector3.forward * dir.y + Vector3.right * dir.x).normalized * dashSpeed;
        //Debug.Log(dashVelocity);
        Vector2 beforedashvel = rb.velocity;

        
        rb.velocity = dashVelocity;

        yield return new WaitForSeconds(dashDuration);

       
        rb.velocity = beforedashvel;

        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
        isDashing = false;
    }

}
