using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootingenemy : Enemy
{
    public GameObject bullet;

    public override IEnumerator attack()
    {
        if (attacking)
        {

        }
        else
        {
            attacking = true;

            Bullet b = Instantiate(bullet,transform.position,Quaternion.LookRotation(target.position - transform.position)).GetComponent<Bullet>();
            b.damage = damage;
            yield return new WaitForSeconds(attackcooldown);

            attacking = false;
        }
        yield return null;
    }
}
