using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class singleshotweapon : Weapon
{
    public bool side = false;
    public bool oncooldown = false;
    public Transform barreltip;
    public AudioClip shootsound;
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
        while (firing)
        {

            side = false;
            //Debug.Log(2);
            Bullet b = Instantiate(bullet, transform.position, Quaternion.LookRotation(barreltip.forward)).GetComponent<Bullet>();
            b.damage = damage;
            b.target = GameObject.Find("Cursor").transform;
            oncooldown = true;
            onesound.playsound(transform.position, shootsound, globalvariables.sfxvolume);
            yield return new WaitForSeconds(cooldown);
            oncooldown = false;

        }
    }
}
