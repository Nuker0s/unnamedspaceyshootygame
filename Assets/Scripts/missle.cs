using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class missle : Bullet
{
    public float homingforce;
    public float maxmultiplier = 2f;

    private void OnCollisionEnter(Collision collision)
    {
        Damagable todamage = collision.collider.gameObject.GetComponent<Damagable>();
        if (todamage != null)
        {
            DealDamage(todamage);
            Destroy(gameObject);
        }
        Destroy(gameObject);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (target != null) 
        {
            rb.AddForce((target.position - transform.position).normalized * math.clamp(Vector3.Distance(transform.position, target.position), 0, maxmultiplier) * homingforce);
            if (rb.velocity.magnitude > 0.5f)
            {
                transform.rotation = quaternion.LookRotation(rb.velocity.normalized,Vector3.up);
            }
        }
        else
        {

        }

        
    }
}
