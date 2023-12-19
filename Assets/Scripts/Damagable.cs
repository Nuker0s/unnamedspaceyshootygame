using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damagable : MonoBehaviour
{
    public float hp = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public virtual void ReciveDamage(float damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Death();
        }
    }
    public virtual void Death() 
    {
        Destroy(gameObject);
    }

}
