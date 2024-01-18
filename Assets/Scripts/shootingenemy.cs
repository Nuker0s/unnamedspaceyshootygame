using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootingenemy : Enemy
{
    public GameObject bullet;
    public AudioClip shootsound;
    public override void Update()
    {
        base.Update();
        try
        {
            if (attacking)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation((target.position - transform.position).normalized), 0.5f);
            }
        }
        catch (System.Exception)
        {

            
        }

    }
    public override IEnumerator attack()
    {
        
        if (attacking)
        {

        }
        else
        {
            attacking = true;

            Bullet b = Instantiate(bullet,transform.position,Quaternion.LookRotation(target.position - transform.position)).GetComponent<Bullet>();
            onesound.playsound(transform.position, shootsound, globalvariables.sfxvolume);
            b.damage = damage;
            yield return new WaitForSeconds(attackcooldown);

            attacking = false;
        }
        yield return null;
    }
}
