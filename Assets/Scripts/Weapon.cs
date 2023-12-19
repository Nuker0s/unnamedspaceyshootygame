using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    
    public GameObject bullet;
    public float damage;
    public float cooldown;
    public bool firing = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public virtual void Fire() 
    {

    }
    public virtual void StopFire() 
    {

    }
}
