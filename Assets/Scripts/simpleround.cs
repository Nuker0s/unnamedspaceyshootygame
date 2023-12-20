using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simpleround : Bullet
{

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        Damagable todamage = collision.collider.gameObject.GetComponent<Damagable>();
        if (todamage != null) 
        {
            DealDamage(todamage);
            Destroy(gameObject);
        }
        //rb.velocity = Vector3.zero;
        rb.AddTorque(new Vector3(Random.Range(-1f,1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)) * Random.Range(-100,100));
        //rb.AddForce(new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)) * Random.Range(-3000, 3000));
        Destroy(gameObject,1);
    }

}
