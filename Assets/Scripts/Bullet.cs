using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 60;
    public float damage = 10;

    // Start is called before the first frame update
    virtual public void Start()
    {
        rb.velocity = transform.forward * speed;
        Destroy(gameObject, 10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public virtual void DealDamage(Damagable target) 
    {
        target.ReciveDamage(damage);
    }
}
