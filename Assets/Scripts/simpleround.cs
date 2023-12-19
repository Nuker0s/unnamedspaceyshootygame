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
        Destroy(gameObject,1);
    }

}
