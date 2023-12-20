using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicCannons : Weapon
{
    public bool side = false;
    public Transform g1;
    public Transform g2;
    public bool oncooldown = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void Fire()
    {
        firing = true;
        if (!oncooldown) 
        {
            StartCoroutine(onfiring());
        }

    }
    public override void StopFire() 
    {
        firing = false;
        
    }
    public IEnumerator onfiring() 
    {
        //Debug.Log(3);
        while(firing)
        {
            if(side)
            {
                side = false;
                //Debug.Log(2);
                Bullet b = Instantiate(bullet, g1.position, Quaternion.LookRotation(transform.forward)).GetComponent<Bullet>();
                b.damage = damage;
                oncooldown = true;
                yield return new WaitForSeconds(cooldown);
                oncooldown = false;
            }
            else
            {
                side = true;
                Bullet b = Instantiate(bullet, g2.position, Quaternion.LookRotation(transform.forward)).GetComponent<Bullet>();
                b.damage = damage;

                oncooldown = true;
                yield return new WaitForSeconds(cooldown);
                oncooldown = false;
            }
            
        }
        
    }
}
