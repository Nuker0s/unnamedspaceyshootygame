using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class biglaser : Weapon
{
    public float range;
    public LayerMask hitmask;
    public LineRenderer laserend;
    public Transform barreltip;
    // Start is called before the first frame update
    void Start()
    {
        laserend.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        laserend.SetPosition(0, barreltip.position);
        if (firing)
        {
            if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, range, hitmask))
            {
                Damagable todamage = hit.collider.gameObject.GetComponent<Damagable>();
                if (todamage != null)
                {
                    todamage.ReciveDamage(damage * Time.deltaTime);
                    laserend.SetPosition(1, hit.point);
                }
                else
                {
                    laserend.SetPosition(1, hit.point);
                }
                

            }
            else
            {
                laserend.SetPosition(1, barreltip.forward * range + barreltip.position);
            }
        }
    }
    public override void Fire()
    {
        firing = true;
        laserend.enabled = true;
    }
    public override void StopFire()
    {
        firing = false;
        laserend.enabled = false;
    }
}
