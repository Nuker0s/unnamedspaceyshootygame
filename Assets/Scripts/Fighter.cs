using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Fighter : MonoBehaviour
{
    [Header("Inputs")]
    public PlayerInput pinput;
    private InputAction move;
    private InputAction dash;
    private InputAction fire;
    private InputAction swapweapons;
    private InputAction interact;

    [Header("Weaponry")]
    public Transform weaponrack;
    public int weaponslots;
    public Weapon weapon;
    [Header("Equpment")]
    public float castrange = 100f;
    public LayerMask layermask;

    [Header("Movement")] 
    public float force;
    public Rigidbody rb;
    public Transform target;
    [Header("Dash")]
    public float dashSpeed = 200f;       
    public float dashDuration = 0.2f;    
    public float dashCooldown = 1.0f;    
    private bool isDashing = false;
    private bool canDash = true;
    public static Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = transform;
        move = pinput.actions.FindAction("Move");
        dash = pinput.actions.FindAction("Dash");
        fire = pinput.actions.FindAction("Fire");
        interact = pinput.actions.FindAction("Interact");
        swapweapons = pinput.actions.FindAction("SwapWeapons");
        equipweapon();

    }

    // Update is called once per frame
    void Update()
    {
        if (weapon != null)
        {
            if (fire.WasPressedThisFrame())
            {

                weapon.Fire();
            }
            if (fire.WasReleasedThisFrame())
            {

                weapon.StopFire();

            }
        }

        if (interact.WasReleasedThisFrame())
        {
            equipweapon();
        }
        if (swapweapons.WasReleasedThisFrame())
        {
            swapweapon();
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
    public void equipweapon() 
    {
        //Debug.Log("equipobeam");
        if (Physics.Raycast(transform.position,transform.forward,out RaycastHit hit,castrange,layermask))
        {
            Debug.Log(hit.collider.gameObject.name);
            Weapon toequip = hit.collider.gameObject.GetComponent<Weapon>();
            if (toequip != null) 
            {
                if (weaponrack.childCount < weaponslots)
                {
                    toequip.Equip(transform);
                    toequip.transform.parent = weaponrack;
                    toequip.transform.SetSiblingIndex(0);
                    weapon = weaponrack.GetChild(0).GetComponent<Weapon>();

                }
                else
                {

                    weapon.UnEquip();
                    weapon.transform.parent = null;
                    weapon.transform.position = toequip.transform.position;

                    toequip.Equip(transform);
                    toequip.transform.parent = weaponrack;
                    toequip.transform.SetSiblingIndex(0);
                    weapon = weaponrack.GetChild(0).GetComponent<Weapon>();


                }
                
            }


        }
    }
    public void swapweapon() 
    {
        if (weaponrack.childCount > 0) 
        {
            weaponrack.GetChild(weaponrack.childCount - 1).SetSiblingIndex(0);
            weapon = weaponrack.GetChild(0).GetComponent<Weapon>();
        }
        
    }

}
