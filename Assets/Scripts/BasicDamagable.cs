using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicDamagable : Damagable
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void ReciveDamage(float damage) 
    {
        hp -= damage;
        if (hp <= 0) 
        {
            Destroy(gameObject); 
        }
    }
}
